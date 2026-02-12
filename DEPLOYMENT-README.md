# Cloud Dental Office - Deployment Guide (DigitalOcean Kubernetes)

This guide helps you deploy the Cloud Dental Office Portal to your DigitalOcean Kubernetes cluster.

## Prerequisites

1.  **DigitalOcean Cluster** is provisioned.
2.  **`kubectl`** and **`doctl`** are installed and configured locally.
3.  **Domain** `clouddentaloffice.com` is pointing to your Ingress Load Balancer IP (configured in step 2).

## Step 0: Domain Configuration (Squarespace to DigitalOcean)

Since you bought your domain on Squarespace, you have two options. **Option A** is recommended for easiest management.

### Option A: Point Nameservers to DigitalOcean (Recommended)
This moves DNS management to DigitalOcean, giving you one place to manage everything.

1.  **Log in to Squarespace** and go to **Domains**.
2.  Click on `clouddentaloffice.com` -> **DNS Settings**.
3.  Select **Nameservers** -> **Use Custom Nameservers**.
4.  Enter these three:
    *   `ns1.digitalocean.com`
    *   `ns2.digitalocean.com`
    *   `ns3.digitalocean.com`
5.  Save.
6.  **Log in to DigitalOcean** -> **Networking** -> **Domains**.
7.  Add `clouddentaloffice.com`.
8.  **Add/Edit 2 Records** to point to your Load Balancer IP (`52.246.254.155`):
    *   **Type**: `A` | **Hostname**: `@` | **Value**: `52.246.254.155`
    *   **Type**: `A` | **Hostname**: `www` | **Value**: `52.246.254.155`

### Option B: Point A Records (Keep DNS at Squarespace)
Use this if you have other services (like email) on Squarespace you don't want to re-configure.

1.  Wait until **Step 2** below is complete and you have your **Load Balancer External IP** (which is: `52.246.254.155`).
2.  **Log in to Squarespace** -> **DNS Settings**.
3.  Add an **A Record**:
    *   **Host**: `@`
    *   **Data/Value**: `52.246.254.155`
4.  Add a second **A Record** (or CNAME):
    *   **Host**: `www`
    *   **Data/Value**: `52.246.254.155` (or CNAME to `clouddentaloffice.com`)

## Step 1: Container Registry

You need a place to store your Docker images.
1.  Create a Container Registry in DigitalOcean.
2.  Login via terminal:
    ```bash
    doctl registry login
    ```

## Step 2: Ingress Controller & Cert Manager

Install NGINX Ingress Controller to handle incoming traffic and Cert-Manager for SSL.

```bash
# Install NGINX Ingress
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.8.2/deploy/static/provider/do/deploy.yaml

# Install Cert-Manager
kubectl apply -f https://github.com/cert-manager/cert-manager/releases/download/v1.12.0/cert-manager.yaml
```

Wait for the Load Balancer IP:
```bash
kubectl get svc -n ingress-nginx ingress-nginx-controller
```
**Point your domain (clouddentaloffice.com) to this External IP in your DNS settings.**

## Step 3: Cluster Issuer for SSL

Create a file `k8s/issuer.yaml` (not created by default) to set up Let's Encrypt:

```yaml
apiVersion: cert-manager.io/v1
kind: ClusterIssuer
metadata:
  name: letsencrypt-prod
spec:
  acme:
    email: admin@clouddentaloffice.com
    server: https://acme-v02.api.letsencrypt.org/directory
    privateKeySecretRef:
      name: letsencrypt-prod
    solvers:
    - http01:
        ingress:
          class: nginx
```
Apply it: `kubectl apply -f k8s/issuer.yaml`

## Step 4: Secrets Configuration

Create the secrets file. DO NOT COMMIT THIS FILE.

You will need the **PostgreSQL Connection String** from your DigitalOcean Managed Database dashboard.
It usually looks like: `Host=YOUR_DO_HOST;Port=25060;Database=clouddental;Username=doadmin;Password=...;SSL Mode=Require;Trust Server Certificate=true`

```bash
kubectl create secret generic clouddental-secrets \
  --from-literal=ConnectionStrings__DefaultConnection="Host=YOUR_DO_DB_HOST;Port=25060;Database=clouddental;Username=doadmin;Password=...;SSL Mode=Require;Trust Server Certificate=true" \
  --from-literal=Jwt__Key="YOUR_LONG_SECURE_RANDOM_KEY" \
  --from-literal=Stripe__SecretKey="sk_live_..."
```

## Step 5: Build & Deploy

### IMPORTANT: Build Command for Mac (Apple Silicon) Users
Since you are building on a Mac (ARM64) but deploying to DigitalOcean (AMD64), you **MUST** use the `--platform linux/amd64` flag. If you don't, the pods will crash with `exec format error`.

1.  **Build the Image:**
    ```bash
    docker build --no-cache --platform linux/amd64 -f CloudDentalOffice.Portal/Dockerfile -t registry.digitalocean.com/clouddental/portal:v4 .
    ```
    *(Increment v4 to v5, etc. for future builds)*

2.  **Push the Image:**
    ```bash
    docker push registry.digitalocean.com/clouddental/portal:v1
    ```
    *Note: Update `k8s/deployment.yaml` image tag if it changes.*

3.  **Apply Manifests:**
    ```bash
    kubectl apply -f k8s/deployment.yaml
    kubectl apply -f k8s/service.yaml
    kubectl apply -f k8s/ingress.yaml
    ```

## Step 6: Verify

Check the status:
```bash
kubectl get pods
kubectl get ingress
```

Visit `https://clouddentaloffice.com`

## Step 7: CI/CD Automation (GitHub Actions)

We have set up a workflow file in `.github/workflows/deploy-portal.yml` that automatically builds and updates the site whenever you push to the `main` branch.

### Required Setup
You must add a secret to your GitHub repository for this to work:

1.  Go to **DigitalOcean** -> **API** -> **Generate New Token** (Select all scopes).
2.  Copy the token.
3.  Go to **GitHub Repo** -> **Settings** -> **Secrets and variables** -> **Actions**.
4.  Click **New repository secret**.
5.  **Name**: `DIGITALOCEAN_ACCESS_TOKEN`
6.  **Value**: (Paste your token)

Once added, any push to `main` will trigger a deployment in about 2-3 minutes.
