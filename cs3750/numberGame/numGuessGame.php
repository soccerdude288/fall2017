<?php
session_start();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title></title>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
		<script type="text/javascript">
			var randomNum = Math.floor(Math.random() * 101);
			$(function(){
				$("#number").text(randomNum);
			});

			var tries = 0;

			function checkGuess(){
				var value = $("#txtGuess").val();
				if(value > randomNum){
					$("#output2").text("Your guess is too high.");
					tries++;
				}
				else if(value < randomNum){
					$("#output2").text("Your guess is too low.");
					tries++;
				}
				else{
					$("#output2").text("Your guess is correct.");
					tries++;
					$.post( "numGuess.php", { count: tries, username:"<?php echo $_SESSION["username"] ?>"} );
				}
			}

			function init(){
				location.reload();
			}
		</script>
	</head>
	<body>
		<h1>Number Guesser</h1>
		
		<form>
			<fieldset>
				<div id="output">
					Guess a number between 0 and 100.
					I'll tell you if you're too high, too low, or correct.
				</div>
				<div style="color:red" id="output2"></div>
				<div id="number"></div>
				<label for>Your Guess</label>
				<input type="text" id="txtGuess"></input>
				<button type="button" onclick="checkGuess()">Check Guess </button>
				<button type="button" id="again" onclick="init()">Try Again</button>
			</fieldset>
		</form>
	</body>
</html>