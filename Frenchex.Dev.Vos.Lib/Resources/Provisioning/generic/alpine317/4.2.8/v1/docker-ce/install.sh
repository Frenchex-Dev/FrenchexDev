#!/usr/bin/env bash

sudo apk update
sudo apk add docker docker-compose
sudo rc-update add docker default
