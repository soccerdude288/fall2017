<html>
<head>
</head>
<body>
<?php
$servername = "localhost";
$username = "W01186504";
$password = "Taylorcs!";
$dbname = "W01186504";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);
// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

$sql = "SELECT id, First, Last FROM TestTable";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    // output data of each row
    while($row = mysqli_fetch_assoc($result)) {
        echo "id: " . $row["id"]. " - Name: " . $row["First"]. " " . $row["Last"]. "<br>";
    }
} else {
    echo "0 results";
}

mysqli_close($conn);
function insert(){
  $value = $_POST["name"];
  $servername = "localhost";
  $username = "W01186504";
  $password = "Taylorcs!";
  $dbname = "W01186504";

  // Create connection
  $conn = new mysqli($servername, $username, $password, $dbname);
  // Check connection
  if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
  } 

  $sql = "INSERT INTO TestTable (First, Last, email)
  VALUES (\"$value\", \"$value\", \"$value\")";

  if ($conn->query($sql) === TRUE) {
      echo "New record created successfully";
  } else {
      echo "Error: " . $sql . "<br>" . $conn->error;
  }

  $conn->close();

};

if(isset($_POST['submit']))
{
   insert();
}
 
?>
<form method="post" action="index.php">
    <input type="text" name="name">
    <input type="submit" value="click" name="submit"> <!-- assign a name for the button -->
</form>

</body>
</html>
