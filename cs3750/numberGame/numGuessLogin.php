<?php
session_start();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title></title>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
		<script type="text/javascript" src="sha.js" ></script>
	</head>
	<body>
		<?php
		if (isset($_GET['invalidUser'])) {
			echo "<div id='error'>Invalid Username</div>";
		}
		if (isset($_GET['duplicateUser'])) {
			echo "<div id='error'>Username Already Exists</div>";
		}
		?>
		<form action="numGuess.php" method="post">
			<fieldset>
				<table>
					<tr>
						<td>Username: </td>
						<td><input type="text" id="username" name="username"></input></td>
					</tr>
					<tr>
						<td>Password: </td>
						<td><input type="password" id="password" name="password"></input></td>
					</tr>
					<tr>
						<td><button onclick="hash()" name="login">Submit</button></td>
						<td><button onclick="hash()" name="newUser">Create New User</button></td>
					</tr>
				</table>
			</fieldset>
		</form>		
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