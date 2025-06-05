To start backend server do the following

> Disclaimer: appropriate tools should be installed (dotnet core, EF core, docker, docker compose, git)

1. Clone repo

```sh
git clone https://github.com/RoundRonin/ASIM.git
```

2. Start docker containers (mainly local DB)

```sh
docker compose up
```

3. Apply migrations to your local DB

from the root of the project:

```sh
cd ./back/Scripts
./updateDB.sh
```

4. Run the server (via docker or on the system directly)

from the root of the project:
```
dotnet run
```

if using docker:
```sh
docker compose up
```
make sure the container is running.
