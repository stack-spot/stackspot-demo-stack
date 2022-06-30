#!/bin/bash    
curl --location --request PUT 'https://runtime-engine-api.runtimes.stackspot.com/apps/{{global_inputs.app_runtime_id}}/deploys/' \
--header 'Content-Type: multipart/form-data' \
--form 'spec=@"./oam.yaml"' \
--form 'target="7adc2243-aefe-4f8a-9298-7ecd27654b38"' 