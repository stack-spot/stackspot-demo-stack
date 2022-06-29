#!/bin/bash    
curl --location --request PUT 'https://runtime-engine-api.runtimes.stackspot.com/apps/{{global_inputs.app_runtime_id}}/deploys/' \
--header 'Content-Type: multipart/form-data' \
--form 'spec=@"{{target_path}}/oam.yaml"' \
--form 'target="87784b3c-6146-4e74-960b-48304665845a"' 