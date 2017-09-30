#!/usr/bin/python

import sqlite3
import csv
import random
import os
import sys

#check for 2 command line args
print(len(sys.argv))
print(sys.argv[0])
if(len(sys.argv) != 3):
	print("Usage: dbload CSVFILE DATABASEFILE")
	sys.exit(1)

print(sys.argv[1])
print(sys.argv[2])


#try
try:
	#open csv
	file = csv.reader(open(sys.argv[1], 'r'), delimiter=',', quotechar='"')
#except
except Exception as inst:
	#exit 1
	print('Error opening input file: ' + str(inst))
	sys.exit(1)

#try
try:
	#open db
	conn = sqlite3.connect(sys.argv[2])
#except
except Exception as inst:
	#exit 1
	print('Error opening db file: ' + str(inst))

curs = conn.cursor()

#if 2 tables exist already, drop them
curs.execute('''drop table if exists classes''')
curs.execute('''drop table if exists students''')

#create 2 tables
curs.execute('''create table classes
	(id text, subjcode text, coursenumber text, termcode text)''')
	
curs.execute('''create table students
	(id text primary key unique, lastname text, firstname text, major text, email text, city text, state text, zip text)''')
	

counter = 0
#for each record in csv (skip 1st)
for row in file:
	counter += 1
	if counter == 1:
		continue
	# 0 id, 1 first, 2 last, 3 email, 4 major, 5 class, 6 termcode, 7 city, 8 state, 9 zip
	r = (row[0], row[2], row[1], row[4], row[3], row[7], row[8], row[9])
	s = row[5].split(" ")
	c = (row[0], s[1], s[2], row[8])
	#query db for w number
	curs.execute("select * from students where\id = '" + row[0] + "'")
	#if not there
	if not curs.fetchone():
		#insert
		curs.execute('''insert into students (id, lastname, firstname, major, email, city, state, zip)
		values(?,?,?,?,?,?,?,?)''', r)
		#print(row[0] + "does not exist")
	curs.execute('''insert into classes (id, subjcode, coursenumber, termcode)
	vales(?,?,?,?)''', c)
	#insert class

#only one commit for speed
conn.commit()

sys.exit(0)
	