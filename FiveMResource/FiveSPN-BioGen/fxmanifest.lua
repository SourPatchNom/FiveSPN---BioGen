fx_version 'bodacious'

name 'FiveSPN-BioGen'
description 'Generates biographical information for players and AI on the server.'
author 'SourPatchNom'
version 'v1.0'
url 'https://itsthenom.com'

use_global_leo = 'true' -- Set to true if you are using FiveSPN-LeoManager (if false, use command /AiInteractToggle command in game)
use_global_cad = 'true' -- Set to true if you are using FiveSPN-QuickCad 
--run_speed_modifier = '1.1999' -- Run speed is multiplied times this number as float x.xxx

games { 'gta5' }

server_script {
	"FiveSpn.BioGen.Server.net.dll"
}

client_script {
	"FiveSpn.BioGen.Client.net.dll"
}

files {
	"FiveSpn.BioGen.Library.dll",
	"Newtonsoft.Json.dll"
}