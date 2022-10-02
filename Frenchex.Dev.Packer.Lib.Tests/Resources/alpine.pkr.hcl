build {
  sources = [
    "source.docker.alpine",
  ]

  provisioner "shell" {
    inline = [
      "apk add nginx"
    ]

    post-processor "docker-tag" {
      repository = "ilhicas/nginx-alpine-packer-build"
      tag        = ["1.0"]
    }
  }
}