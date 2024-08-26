#!/usr/bin/env just --justfile

build:
    dotnet build -c Release

test:
    dotnet test

commit:
    #!/usr/bin/env bash
    set -euxo pipefail
    time=$(date "+%Y%m%d")
    message="$time finished."

    git add -A
    git commit -m "$message"
    git push

pull id: build
    #!/usr/bin/env bash
    cd LeetCodeSharp
    dotnet run --project ../LeetCodeSharp.Fetcher/LeetCodeSharp.Fetcher.csproj -- {{id}}