# Traveler

This repository contains a completely broken, error prone and unmaintainable program.
Your mission (if you chose to accept it) is to make it working 
and also make it as pretty, readable and maintainable as you possibly can.

## The challenge

You've got input data that describes zero to many 
trips for a robot.

```
// First trip
POS=0,1,N
FFFRFFF
BBFLBRFFFF

// Second trip
POS=5,5,N
BBFFRFFFFFFFF
LLFFFFLFFFF
```

The first line `POS=0,0,N` describes the initial position
of the robot. In this case position `0`,`0` _(x,y)_ facing `north`.

```
N = North
S = South
E = East
W = West
```

The next part represents (zero to many) commands that 
moves or rotates the robot.

```
F = Move forward
B = Move backwards
L = Rotate left
R = Rotate right
```

The result from running the program should be the 
coordinates and direction of the robot's destination.

```
X=3 Y=2 D=N
X=-1 Y=12 D=W
X=54 Y=1 D=S 
```

Anything is allowed as long as the unit tests pass.  
Go nuts! 😉

## Prerequisites

To build and run this code, you will need the .NET Core SDK 
version 3.0.100, which can be downloaded from
https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-windows-x64-installer.

## Running

Open a command prompt in the root and run:

```
> dotnet run --project ./src/Traveler/Traveler.csproj ./data/input.txt
```

## Running tests

To run the test suite outside of Visual Studio, 
open a command prompt in the root and run:

```
> dotnet test
```