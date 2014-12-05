import sys

lines = [l.rstrip() for l in sys.stdin.readlines()]

i = 0
while True:
    (nJack, nJill) = [int(v) for v in lines[i].rstrip().split()]
    i += 1
    jackCDs = {}
    nBoth = 0

    if nJack == 0 and nJill == 0:
        break

    for j in range(i, i + nJack):
        jackCDs[lines[j]] = True

    i = j + 1

    for j in range(i, i + nJill):
        try:
            if jackCDs[lines[j]]:
                nBoth += 1
        except KeyError:
            pass

    i = j + 1

    print nBoth
