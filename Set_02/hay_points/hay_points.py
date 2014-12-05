import sys

(nWords, nJobDesc) = [int(v) for v in sys.stdin.readline().rstrip().split()]

words = {}

for i in range(nWords):
    line = sys.stdin.readline().rstrip().split()
    ammount = int(line[1])
    word = line[0]
    words[word] = ammount

for i in range(nJobDesc):
    result = 0
    for line in sys.stdin:
        if(line[0] == '.'):
            print result
            break
        else:
            for w in line.rstrip().split():
                try:
                    result += words[w]
                except KeyError:
                    pass
