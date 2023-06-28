from main.py.pandas.dataAnalysisTesting import getDictForDE

#Lose typisiere Sprachen treiben mich irgendwann noch in den Wahnsinn ahgdfkghsrdhgidofusgergkdfg
#Dieser ganze Aufstand hätte verhindert werden können, aber wer ahnt schon das Python bei Division als
#Datentyp einen float zurückgibt, mit statischer Typisierung wäre das nicht passiert.

print("Wie viele Daten sollen pro Ortschaft ausgewertet werden? (zwischen 25 und 10.000, in 25er-Schritten)")
countInput = input()
jobCountPerOrtschaft = int(countInput)
if jobCountPerOrtschaft < 25:
    jobCountPerOrtschaft = 25
while jobCountPerOrtschaft % 25 != 0:
    jobCountPerOrtschaft += 1
if jobCountPerOrtschaft > 10000:
    jobCountPerOrtschaft = 10000

getDictForDE(int(jobCountPerOrtschaft / 25))
