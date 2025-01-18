# Fetch

A basic web API rewards processor.

## Installation

1. Clone this repository
2. From the root of the repository, run the following commands:
```bash
# Build the Docker image
docker build -t fetch-webapi -f ./Fetch.WebApi/Dockerfile .

# Run the container
docker run -p 32769:8080 fetch-webapi
