<?php
if (isset($_GET['logout'])) {
	session_destroy();
}
session_start();

?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title></title>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
		<script type="text/javascript" src="sha.js" ></script>
		<!-- Latest compiled and minified CSS -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

		<!-- Optional theme -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

		<!-- Latest compiled and minified JavaScript -->
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
	</head>
	<body>
		<div class="container">
		<h1>Number Guessing Game Login</h1>
			<?php
			if (isset($_GET['invalidUser'])) {
				echo "<div class='alert alert-danger'>Invalid Username/Password</div>";
			}
			if (isset($_GET['duplicateUser'])) {
				echo "<div class='alert alert-danger'>Username Already Exists</div>";
			}
			if (isset($_GET['success'])) {
				echo "<div class='alert alert-success'>Account Created</div>";
			}
			?>
			<form action="numGuess.php" method="post">
				<div class="form-group">
					<label for="username">Username</label>
					<input type="text" class="form-control" id="username" name="username"></input>
				</div>
				<div class="form-group">
					<label for="password">Password</label>
					<input type="password" id="password" name="password" class="form-control"></input>
				</div>
				<button onclick="hash()" name="login" class="btn btn-defualt">Submit</button>
				<button onclick="hash()" name="newUser" class="btn btn-defualt">Create New User</button>
			
			</form>	
		</div>		
	</body>
	
	
	<script type="text/javascript">
	
	function hash(){
		var item = SHA256($("#username").val() + ":" + $("#password").val());
		$("#password").val(item);
	}
	
	function loginUser(){
		var salted2 = SHA256($("#username").val() + ":" + $("#password").val());
		$.post( "numGuess.php", { username: $("#username").val(), password: salted2, login: true} );
	}
		
	function sendUserPassword(){
		var salted = SHA256($("#username").val() + ":" + $("#password").val());		
		$.post( "numGuess.php", { username: $("#username").val(), password: salted, newUser: true} );
	}
	</script>
</html>