#!/bin/bash
# Seed Demo User to Production Database
# This script connects to your DigitalOcean PostgreSQL and adds the demo user

echo "🔧 Setting up port forward to PostgreSQL database..."

# Extract database credentials from the secret
DB_CONN=$(kubectl --kubeconfig=clouddentaloffice-kubeconfig.yaml get secret clouddental-secrets -n clouddental -o jsonpath='{.data.ConnectionStrings__DefaultConnection}' | base64 --decode)

# Parse connection string (macOS compatible)
DB_HOST=$(echo "$DB_CONN" | sed -n 's/.*Host=\([^;]*\).*/\1/p')
DB_PORT=$(echo "$DB_CONN" | sed -n 's/.*Port=\([^;]*\).*/\1/p')
DB_NAME=$(echo "$DB_CONN" | sed -n 's/.*Database=\([^;]*\).*/\1/p')
DB_USER=$(echo "$DB_CONN" | sed -n 's/.*Username=\([^;]*\).*/\1/p')
DB_PASS=$(echo "$DB_CONN" | sed -n 's/.*Password=\([^;]*\).*/\1/p')

echo "Database: $DB_NAME @ $DB_HOST:$DB_PORT"
echo ""
echo "📝 Executing seed script..."

# Use psql to connect and run the seed script
PGPASSWORD="$DB_PASS" psql -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" -d "$DB_NAME" -f db/seed-demo-user.sql

echo ""
echo "✅ Demo user seeded!"
echo ""
echo "Login credentials:"
echo "  URL: https://clouddentaloffice.com/login"
echo "  Email: demo@clouddentaloffice.com"
echo "  Password: Password123!"
