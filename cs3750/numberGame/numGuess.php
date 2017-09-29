<?php


	session_start();

	if(isset($_POST['login'])){
		logUserIn();
	}
	if(isset($_POST['newUser'])){
		insertUser();
	}
	if(isset($_POST['count'])){
		addScore();
	}

	
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
	


	function insertUser(){
		$username = $_POST["username"];
		$password = $_POST["password"];
		$conn = newConnection();
		
		$sqll = "SELECT username FROM Users WHERE username=\"$username\"";
		$resultt = mysqli_query($conn, $sqll);
		if (mysqli_num_rows($resultt) > 0) {
			header('Location: numGuessLogin.php?duplicateUser="true"');
			exit();
		} else {
			$sql = "INSERT INTO Users (username, password)
			VALUES (\"$username\", \"$password\")";
			if ($conn->query($sql) === TRUE) {
					header('Location: numGuessLogin.php?success="true"');
					exit();
			} else {
					echo "Error: " . $sql . "<br>" . $conn->error;
			}
				
		}
		$conn->close();
	}
	
	function logUserIn(){
		$conn = newConnection();
		echo "we are here";
		$username = $_POST["username"];
		$password = $_POST["password"];
		echo $password;
		$sql = "SELECT username, password FROM Users Where username=\"$username\" AND password=\"$password\"";
		$result = mysqli_query($conn, $sql);
		if (mysqli_num_rows($result) > 0) {
			// output data of each row
			echo "good";
			$_SESSION["username"] = "$username";
			header('Location: numGuessGame.php');
			exit();
		} else {
			echo "bad stuff";
			header('Location: numGuessLogin.php?invalidUser="true');
			exit();
		}
		
		$conn->close();
	}
	
	function addScore(){
		$conn = newConnection();
		$count = $_POST["count"];
		$username = $_POST["username"];
		
		$sql1 = "SELECT ID FROM Users Where username='$username'";
		$result1 = mysqli_query($conn, $sql1);
		if (mysqli_num_rows($result1) > 0) {
			while($row = mysqli_fetch_assoc($result1)) {
				$ID = $row["ID"];
			}
			
		} else {
			echo "Bad things happened";
		}
		
		$sql = "INSERT INTO Score (Score, UserID)
		VALUES (\"$count\", \"$ID\")";
		if ($conn->query($sql) === TRUE) {
			
		} else {
				echo "Error: " . $sql . "<br>" . $conn->error;
		}
		$conn->close();	
		
	}
	
	function getScores(){
		$conn = newConnection();
		
		$sql = "SELECT USER.username username, S.Score scores FROM `Score` S INNER JOIN `Users` USER ON S.USERID = USER.ID ORDER BY S.score DESC";
		$result = mysqli_query($conn, $sql);

		if (mysqli_num_rows($result) > 0) {
			// output data of each row
			while($row = mysqli_fetch_assoc($result)) {
				echo "Username: " . $row["username"]. " - Score: " . $row["scores"] . "<br>";
			}
		} else {
			echo "0 results";
		}
		
		$conn->close();
	}

?>