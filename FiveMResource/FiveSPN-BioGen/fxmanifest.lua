fx_version 'bodacious'

name 'FiveSPN-BioGen'
description 'Generates biographical information for players and AI on the server.'
author 'SourPatchNom'
version 'v1.0'
url 'https://itsthenom.com'

games { 'gta5' }

server_script {
	"FiveSpn.BioGen.Server.net.dll"
}

file 'Newtonsoft.Json.dll'