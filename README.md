# FrenchexDevX

## What is it about ?

It is about helping sofware engineering experience.

### Who does it help ?

It helps developers, freelance and companies crafting softwares

### To do what ?

To better their developer experience and acces to software development infrastructure

### How ?

By leveraging existing and proven technologies like virtualization and containerization by means of tools and scripts wrapping and super charging them, helping the developer setup its developer computer and its working software instances, in a replicable way.

### What is the goal ?

* Being able to replicate your developer setup
* Being able to create new instance of your working software instance

### What are the main benefits ?

Expected benefits are :

* better onboarding,
* better testability of the system (think of upgrades),
* debuggability,
* replicability,
* faster time to work (setting up a new instance can be cumbersome),
* reusable templates

## Main points addressed

### Inclusion

As a developer

* it can be hard to start a new projet on a new technology
* it can be hard to separate all the projects we are working on, with different versions of different techs not meant to stand side by side
* it can be hard to start an enterprise-grade product with all its dependencies

Thanks to templating and registries, developers can shop in and take what they need and see how it works underneath, making them better and reducing failure

### Accessibility

As a developer,

* The usage of many technologies can diminish software engineer productivity
* These techs must be easy to use as a docker container is to use and build

### Eco system

As a developer,

* by using templates et being able to create and publish, we do not lose time to create and test, less time and power consumption at creating and testing infrastructures

## Products

### Packer On Steroid

* PackerLib = wrapper C# de Packer : Open source
* PackerOnSteroid = surcharge de Packer lib
  * permet de créer une instance PackerOnSteroid
  * permet de gérer des repositories de provisioning (peut être un git, un répertoire)
  * permet de configurer par cli l'instant PoS

### Vagrant On Steroid

* VagrantLib = wrapper C# de Vagrant : Open source
* VagrantOnSteroid = surcharge de Vagrant en c# : open source, cli
  * permet de créer une instance Vagrant multi-machine (= une instance VoS)
  * permet de gérer des repositories de provisioning (peut être un git, un répertoire, anything)
  * permet de configurer par cli l'instance VoS
  * ajout de types de machines,
    * lien avec PackerOnSteroid
      * permet de créer des images à partir de PackerOnSteroid, comme le docker compose build
      * de machines,
      * de registres de provisioning
      * les types de machines définissent les provisioning utilisés par registre via @registry/exact/script/path.ps1
      * les registry sont des git qu'on clone à la volé comme github actions
* VagrantOnSteroidServer = VoS avec serveur web + IDE online
  * permet de gérer un ensemble d'instances VoS sur une machine
  * fourni une API web pour manipuler les instances VoS d'une machine
  * fourni une API pour gérer la connectivité du host
* VagrantOnSteroidCentralServer = centralisation des VoSServers
  * permet de gérer un ensembe de serveurs VoS qui ont plusieurs instances VoS installées
* VagrantOnSteroidServerConnector = connection à des instances VoS
  * permet de se connecter à une instance VoS pour test et debug

### Voses

* Voses : un docker-compose pour plusieurs instances VagrantOnSteroid

#### structure d'un voses-compose.yml

```yaml
version: '1.0'
networks:
  - infra-dev:
  - infra-ci:
  - registry-prod:
  - infra-prod:
volumes:
 - infra-dev:
 - infra-ci:
 - registry-prod:
 - infra-prod:
voses:
  - name: dev
    source: ./dev/vos.yml
    networks:
      - infra-dev
      - infra-ci
  - name: ci
    source: ./ci/vos.yml
    networks:
      - infra-ci
      - registry-prod
  - name: staging
    source: ./staging/vos.yml
    networks:
      - infra-staging
      - registry-prod
  - name: prod
    source: ./prod/vos.yml
    networks:
      - infra-prod
      - registry-prod
```

#### structure d'un vos.yml

```yaml
version: '1.0'
machine-types:
  - name: docker-host
    memory: 4gb
    cpus: 4
machines:
  - name: k8s-cluster
  - instances: 5  
```

```powershell
PS > voses up dev,ci,staging,prod --parallel
[info] loading configuration
[info] loading voses-compose.yml
[info] up dev
    [info] up k8s-cluster with 5 instances
    [vagrant output] ...\/\/... (nested cursed output of the vagrant up command for all vos instances)
[info] up ci
    [info] up k8s-cluster with 5 instances
    [vagrant output] ...\/\/... (nested cursed output of the vagrant up command for all vos instances)
[info] up staging
    [info] up k8s-cluster with 5 instances
    [vagrant output] ...\/\/... (nested cursed output of the vagrant up command for all vos instances)
[info] up prod
    [info] up k8s-cluster with 5 instances
    [vagrant output] ...\/\/... (nested cursed output of the vagrant up command for all vos instances)

```
