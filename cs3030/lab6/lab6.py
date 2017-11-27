#!/usr/bin/python

import sys
import random
import shlex

if len(sys.argv) != 3:
	print("Usage: ./filemaker INPUTCOMMANDFILE OUTPUTFILE RECORDCOUNT")
	sys.exit(1)
	
inputF = open(sys.argv[1] , "r")
outputF = open(sys.argv[2] , "w")
recordCount = sys.argv[3]

myDict = {};
randomData = {};
commands = {};

try:
	for i , line in enumerate(inputF):
		ln = shlex.split(line , True);
		if ln[0] == "HEADER":
			outputF.write(ln[1])
		elif ln[0] == "STRING":
			commands.append(ln)
		elif ln[0] == "REFER":
			commands.append(ln)
		elif ln[0] == "NUMBER":
			commands.append(ln)
		elif ln[0] == "FILEWORD":
			fileName = ln[2]
			rfile = open(filename, "r")
			randomData[rfile] = rfile.readlines()
			commands.append(ln)
			rfile.close()
finally:
	inputF.close();

for i in range(recordCount):
	randomVal = {};
	for ln in commands:
		if ln[0] == "STRING":
			outputF.write(ln[1])
		elif ln[0] == "FILEWORD":
			list = randomData[ln[2]]
			val = list[random.randint(0 , len(list -1))]
			randomVal[ln[1]] = val
			outputF.write(val)
		elif ln[0] == "NUMBER":
			label = ln[1]
			minN = ln[2]
			maxN = ln[3]
			rnd = random.randint(minN , maxN)
			randomVal[label] = rnd
			outputF.write(rnd)
		elif ln[0] == "REFER":
			label = ln[1]
			val = randomVal[label]
			outputF.write(val) 

outputF.close()
sys.exit(0)
