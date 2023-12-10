

lines = []

with open("input") as file:
    lines = [line.strip() for line in file.readlines()]



# def digitsFromWords(text: str):
#     digits = {
#         "1": 1, "2": 2, "3": 3, "4": 4, "5": 5,
#         "6": 6, "7": 7, "8": 8, "9": 9, "0": 0,
#         "one": 1, "two": 2, "three": 3, "four": 4, "five": 5,
#         "six": 6, "seven": 7, "eight": 8, "nine": 9, "zero": 0,
#     }
#     numbers = [0 for x in range(len(text))]
#     for digit in digits:
#         index = text.find(digit)
#         if index != -1:
#             numbers[index] = digits[digit]
#     print(text, [x for x in numbers if x != 0])

#     return numbers

# def firstLastDigitSum(digits: list[int]) -> int:
#     digits = [x for x in digits if x != 0]
#     sum = int(str(digits[0]) + str(digits[-1]))
#     print(sum)
#     return sum


def get_numbers(text: str):
    digits = {
        "one": "o1e", 
        "two": "t2e",
        "three": 't3e',
        "four": "f4r",
        "five": "f5e",
        "six": "s6x",
        "seven": "s7n",
        "eight": "e8t", 
        "nine": "n9e", 
    }
    for digit in digits:
        text = text.replace(digit, digits[digit])
    numbers = [x for x in text if x.isnumeric()]
    return int(numbers[0] + numbers[-1])

answer = 0
for line in lines:
    answer += get_numbers(line)
print(answer)