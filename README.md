# FiveSPN-BioGen

FiveSPN-BioGen is a FiveM resource for generating random names and dates of birth for online server gameplay. These names can be used to quickly create personas for role-players or to generate information given to game AI.
FiveSPN-Persona and FiveSPN-Ai use this resource. 

## Prerequisites

For best performance and monitoring, make sure the FiveSPN--Logger resource is utilized properly. This resource is available in the [Full Suite](https://github.com/SourPatchNom/FiveSPN---Suite) or from the [Source](https://github.com/SourPatchNom/FiveSPN---Logger)

## Installation

### Step One: Add the resource to your server.
Copy the folder inside of the FiveMResource folder into your server's resources folder and add it to the server.cfg with the following line.
```
start FiveSPN-BioGen
```

## Usage

Client based request - receive event handlers examples:
```csharp
    EventHandlers["FiveSPN-BioGen-ClientGetName"] += new Action<string, string>(ClientRxName);
    EventHandlers["FiveSPN-BioGen-ClientGetDob"] += new Action<string>(ClientRxDob);
    EventHandlers["FiveSPN-BioGen-ClientGetAll"] += new Action<string, string, string, bool>(ClientRxAll);
```

Client based request - event triggers examples:
```csharp
    TriggerServerEvent("FiveSPN-BioGen-ClientGetName", true);
    TriggerServerEvent("FiveSPN-BioGen-ClientGetName", false);
    TriggerServerEvent("FiveSPN-BioGen-ClientGetDob");
    TriggerServerEvent("FiveSPN-BioGen-ClientGetDob");
    TriggerServerEvent("FiveSPN-BioGen-ClientGetAll", true);
    TriggerServerEvent("FiveSPN-BioGen-ClientGetAll", false);
```

Client based request - example output:
```text
Received Name: Leland Laico
Received Name: Joella Nanneman
Received DOB: 01/03/1965
Received DOB: 05/09/1964
Received All: Bilal Lovig 05/26/1971 Male
Received All: Viviana Paulini 11/11/1986 Female
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Discord
FiveM development can be even more amazing if we work together to grow the open source community!

Lets Collab! Join the project discord at [itsthenom.com!](http://itsthenom.com/)
## Licensing

    Copyright ©2022 Owen Dolberg (SourPatchNom)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

In the hopes that the greater community may benefit, you may use this code under the [GNU Affero General Public License v3.0](LICENSE).

This resource distribution utilizes the [Newtonsoft.JSON Library](https://github.com/JamesNK/Newtonsoft.Json) under the [MIT License](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md).

This software references the CitizenFX.Core.Server and CitizenFX.Core.Client nuget packages (c) 2017-2020 the CitizenFX Collective used under [license](https://github.com/citizenfx/fivem/blob/master/code/LICENSE) and under the [FiveM Service Agreement](https://fivem.net/terms)

Never heard of FiveM? Learn more about the CitizenFX FiveM project [here](https://fivem.net/)

## Credits
* <b>Sloosecannon</b> for inspiration and rubber ducky assistance during the initial conception of all this in 2020.
* <b>AGHMatti</b> I think... for reference on the http helper, really wish I could locate the source repo now.