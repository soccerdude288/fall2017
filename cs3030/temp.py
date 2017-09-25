#!/usr/bin/python

#Taylor Earl
#Assignment 4
#Temperature Conversion Program



def fahrenheitToCelsius(f):
	rVal = ((f-32.0)*(5.0/9.0))
	return rVal
def celsiusToFahrenheit(c):
	rVal = ((9.0/5.0) * c + 32.0)
	return rVal



#welcome message
print("Welcome to the CS 3030 Temperature Conversion Program")

while True:
	#take in user input
	#3 will quit the program
	print("\nMain Menu\n\n")
	print("1:Fahrenheit to Celsius")
	print("2:Celsius to Fahrenheit")
	print("3:Exit Program")
	x = raw_input("""\nPlease Enter 1, 2 or 3: """)
	
	#make sure user input is a number
	try:
		x = int(x)
	except:
		print("\nInvalid entry")
		continue

	#logic for user input. 3 is quit, 1 f->c, 2 c->f
	if x == 3:
		exit(0)
	elif x == 1:
		#take more input
		uInput = raw_input("""\nPlease enter degrees Fahrenheit: """)
		try:
			#convert string to float
			uInput = float(uInput)
			#run formula
			results = fahrenheitToCelsius(uInput)
			#print results
			print("%.1f degrees Fahrenheit equals %.1f degrees Celsius" % (uInput,results))
		except:
			print("\Invalid entry")
		continue
	elif x == 2:
		input = raw_input("""\nPlease enter degrees Celsius: """)
		try:
			#convert string to float
			input = float(input)
			#run formula
			result = celsiusToFahrenheit(input)
			#print results
			print("%.1f degrees Celsius equals %.1f degrees Fahrenheit" % (input,result))
		except:
			print("\nInvalid entry")
		continue
	else:
		continue