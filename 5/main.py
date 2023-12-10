lines = []

seeds = []

with open("/home/matixon/programowanie/adventofcode2023/5/input") as f:
    lines = [l.strip() for l in f.readlines()]
    seeds = lines[0].split(":")[1].split(" ")

def mapRanges(value: int, destination: int, source: int, length: int):

    min_source = source
    max_source = source+length-1

    # print(source_range)
    # print(destination_range)
    if value < min_source or value > max_source:
        return value
    diff = abs(source-destination)
    return value+diff


print(seeds)
print(mapRanges(74,68,64,13))