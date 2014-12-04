import sys
import re

while True:
    raw = sys.stdin.readline().rstrip('\n').split(" ")
    nPlayers = int(raw[0])
    if(nPlayers < 1):
        break

    print 'nPlayers: ' + str(nPlayers)

    nGames = int(raw[1])
    print 'nGames: ' + str(nGames)

    for i in range(nGames):
        rawMoves = re.findall("\d [a-z]*", sys.stdin.readline())
        for m in rawMoves:
            print m
