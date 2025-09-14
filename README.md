# How to Clone the Repository

To get a copy of this project on your machine, open a terminal and run:

```sh
git clone https://github.com/parthbirlaSWE/RobotSimulator.git
cd RobotSimulator
```

# Toy Robot Tabletop Simulator

This is a simple C# console app I wrote to simulate a toy robot moving around on a 5x5 table. The robot can be placed, moved, rotated, and will report its position. I made sure it can't fall off the table, and it only starts listening to commands after you place it somewhere valid.

## How to Use

This console application required Latest .Net 9.0. To try it out:

1. Clone this repo and open a terminal in the project folder.
2. Build it:
   ```sh
   dotnet build
   ```
3. Run it with the included test file:
   ```sh
   dotnet run commands.txt
   ```
   Or just run it and type commands yourself:
   ```sh
   dotnet run
   ```

## Commands

* `PLACE X,Y,F` (e.g. `PLACE 0,0,NORTH`)
* `MOVE`
* `LEFT`
* `RIGHT`
* `REPORT`

The table is 5x5, with (0,0) in the bottom-left (south-west) corner. The robot ignores any move that would make it fall off.

If you try to start with anything except a PLACE command, the app will throw an error. (I figured that's the safest way to make sure the robot is always on the table!)

## Testing

Check out `commands.txt` for all relevant test cases, including edge cases and invalid moves.
## Files
