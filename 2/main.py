from dataclasses import dataclass
import re
import numbers

@dataclass
class Cube_set:
    red: int
    green: int
    blue: int

@dataclass
class Game:
    id: int
    cube_sets: list[Cube_set]



games: list[Game] = []
lines = []
with open("input") as file:
    lines = [line.strip("\n") for line in file.readlines()]

for line in lines:
    cube_sets = []
    id = line.split(":")[0].split()[1]
    cube_sets_str = line.split(":")[1].split(";")
    for cube_set in cube_sets_str:

        red = cube_set[cube_set.find("red")-3:cube_set.find("red")-1]
        green = cube_set[cube_set.find("green")-3:cube_set.find("green")-1]
        blue = cube_set[cube_set.find("blue")-3:cube_set.find("blue")-1]

        red = int(red) if red.strip().isnumeric() else 0
        green = int(green) if green.strip().isnumeric() else 0
        blue = int(blue) if blue.strip().isnumeric() else 0

        curr_set = Cube_set(red,green,blue)
        cube_sets.append(curr_set)
    
    game = Game(id,cube_sets)
    games.append(game)


def isGamePossible(game: Game):
    MAX_RED = 12
    MAX_GREEN = 13
    MAX_BLUE = 14
    for cube_set in game.cube_sets:
        if cube_set.blue > MAX_BLUE:
            return False
        if cube_set.red > MAX_RED:
            return False
        if cube_set.green > MAX_GREEN:
            return False
    return True

def getMinSet(game: Game):
    red = max([x.red for x in game.cube_sets])
    green = max([x.green for x in game.cube_sets])
    blue = max([x.blue for x in game.cube_sets])
    return Cube_set(red,green,blue)
    

# part 1
# sum = 0

# for game in games:
#     if(isGamePossible(game)):
#         sum += int(game.id)

# print(sum)

power_sum = 0
for game in games:
    min_set = getMinSet(game)
    power = min_set.blue*min_set.red*min_set.green
    power_sum+=power

print(power_sum)