<?php


	session_start();

	if(isset($_POST['submit'])){
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
		$newPassword = hash('sha256', $username.":".$password);
		$conn = newConnection();
		$sql = "INSERT INTO Users (username, password)
		VALUES (\"$username\", \"$newPassword\")";
		if ($conn->query($sql) === TRUE) {
				header('Location: numGuessLogin.php');
				exit();
		} else {
				echo "Error: " . $sql . "<br>" . $conn->error;
		}
		$conn->close();
	}
	
	function logUserIn(){
		$conn = newConnection();
		$username = $_POST["username"];
		$password = $_POST["password"];
		$newPassword = hash('sha256', $username.":".$password);
		
		$sql = "SELECT username, password FROM Users Where username='$username' AND password='$newPassword'";
		$result = mysqli_query($conn, $sql);
		if (mysqli_num_rows($result) > 0) {
			// output data of each row
			$_SESSION["username"] = "$username";
			header('Location: numGuessGame.php');
		} else {
			header('Location: numGuessLogin.php');
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
		
		$conn->close();
	}

?>