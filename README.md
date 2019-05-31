# KMD Logic Day - Workshop
Example client, that sends SMS and audits events through Logic API. Whole application was written during the Logic Day Workshop.

## Usage
1. (Go to step 3, if you configured SMS provider in Logic Console) Go to [Twilio](https://www.twilio.com/) or [LINK Mobility](https://www.linkmobility.com/) and create account.
2. Login at [Logic Console](https://console.kmdlogic.io) and configure new SMS provider.
3. [Download and install .NET Core 2.2](https://dotnet.microsoft.com/download)
4. Open solution in Visual Studio 2017 / 2019
5. Fulfill parameters in `LogicEnvironment.cs` file. Each parameter must not be empty.
6. In `Program.cs` change local variable `toPhoneNumber` to destination phone number.
7. Run solution.

## Essential links
1. Logic Console -> https://console.kmdlogic.io
2. Logic API example clients -> https://github.com/kmdlogic/
