<?php
session_start();
function newConnection(){
		$servername = "localhost";
		$username = "W01186504";
		$password = "Taylorcs!";
		$dbname = "W01186504";

		$conn = mysqli_connect($servername, $username, $password, $dbname);
		if (!$conn) {
			die("Connection failed: " . mysqli_connect_error());
		}
		return $conn;
	}
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title></title>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
		<!-- Latest compiled and minified CSS -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

		<!-- Optional theme -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

		<!-- Latest compiled and minified JavaScript -->
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
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
					$("#output2").addClass("alert alert-danger");
					tries++;
				}
				else if(value < randomNum){
					$("#output2").text("Your guess is too low.");
					$("#output2").addClass("alert alert-danger");
					tries++;
				}
				else{
					$("#output2").text("Your guess is correct.");
					$("#output2").removeClass("alert alert-danger");
					$("#output2").addClass("alert alert-success");
					tries++;
					$.post( "numGuess.php", { count: tries, username:"<?php echo $_SESSION["username"] ?>"} );
					location.reload(true);
				}
			}

			function init(){
				location.reload(true);
			}
			
			function logout(){
				window.location = "numGuessLogin.php?logout='true'";
			}
		</script>
	</head>
	<body>
	<div class="container">
		<h1>Number Guesser</h1>
		<?php 
		if (!isset($_SESSION["username"])) {
			echo "<div class='alert alert-danger'>You must login to view this page</div>";
			echo "<button onclick='logout()' class='btn btn-default'>Go to Login</button>";
		}
		else{
			?>
			<form>
				<fieldset>
					<div id="output">
						Guess a number between 0 and 100.
						I'll tell you if you're too high, too low, or correct.
					</div>
					<div id="output2"></div>
					<div id="numberr"></div>
					<label for>Your Guess</label>
					<input type="text" id="txtGuess"></input>
					<button type="button" onclick="checkGuess()" class="btn btn-default">Check Guess </button>
					<button type="button" id="again" onclick="init()" class="btn btn-default">Try Again</button>
				</fieldset>
				</form>
				<h1>High Score Table</h1>
				<table class="table table-striped">
					<tr>
						<th>Username</th>
						<th>Score</th>
				</tr>
				<?php
				$conn = newConnection();
				
				$sql = "SELECT USER.username username, S.Score scores FROM `Score` S INNER JOIN `Users` USER ON S.USERID = USER.ID ORDER BY S.score LIMIT 10";
				$result = mysqli_query($conn, $sql);

				if (mysqli_num_rows($result) > 0) {
					// output data of each row
					while($row = mysqli_fetch_assoc($result)) {
						echo "<tr><td>" . $row["username"]. "</td><td>" . $row["scores"] . "</td></tr>";
					}
				} else {
					echo "0 results";
				}
				
				$conn->close();
			echo "</table>";
		}
		?>
		</div>
	</body>
</html>