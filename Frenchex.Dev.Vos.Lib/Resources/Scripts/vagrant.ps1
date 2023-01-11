param(
    [Parameter(Mandatory=$true)][string] $Name,
    [int] $Instance = 0,
    [switch] $Rince,
    [switch] $ProvisionDockerInstall,
    [switch] $Ssh,
    [switch] $Destroy,
    [switch] $Status,
    [switch] $VagrantName,
    [switch] $VagrantInstance
)

$InstanceStr = $Instance.ToString("00")
$DeducedVagrantName = "${Name}-${InstanceStr}"

if ($VagrantInstance) {
    $InstanceStr
}

if ($VagrantName) {
    $DeducedVagrantName
}

if ($Rince){
    vagrant destroy -f $DeducedVagrantName
    vagrant up --no-provision $DeducedVagrantName
}

if ($ProvisionDockerInstall) {
    vagrant provision $DeducedVagrantName --provision-with "docker-ce/install"
}

if ($Ssh) {
    vagrant ssh $DeducedVagrantName
}

if ($Destroy) {
    vagrant destroy -f $DeducedVagrantName
}

if ($Status) {
    vagrant status $DeducedVagrantName
}
