#!/usr/bin/env bash

apk update
apk add docker docker-compose
rc-update add docker default