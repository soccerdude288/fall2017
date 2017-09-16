<?php
session_start();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title></title>
	</head>
	<body>
		<form method="post" action="numGuess.php">
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
						<td><button name="submit">Submit</button></td>
						<td><button name="newUser">Create New User</button></td>
					</tr>
				</table>
			</fieldset>
		</form>		
	</body>
</html>