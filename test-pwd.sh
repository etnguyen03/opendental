#!/bin/bash
# Test password hash validation

HASH='$2a$11$N9qo8uLXtOJ7H6xOqG4wg.5f4CtS9ExN0JmCvxF.AGo8nCRXCCZWi'

kubectl --kubeconfig=clouddentaloffice-kubeconfig.yaml exec -n clouddental deployment/clouddental-portal -- sh -c "
echo 'Testing password hash verification...'
echo 'Hash: $HASH'
echo 'Password: Password123!'
"
