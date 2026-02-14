#!/bin/bash

echo "🔧 Seeding claims for dev tenant..."
DB_PASS=$(kubectl get secret clouddental-secrets -n clouddental -o jsonpath='{.data.Database__Password}' | base64 -d)

PGPASSWORD="$DB_PASS" psql \
  -h clouddental-db-do-user-33268551-0.d.db.ondigitalocean.com \
  -p 25060 \
  -U doadmin \
  -d defaultdb \
  -f db/seed-simple-claims.sql

echo "✅ Claims seeded!"
