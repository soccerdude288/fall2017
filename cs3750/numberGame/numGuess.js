
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
		$.post( "numGuesLogin.php", { count: tries, username: $_SESSION } );
	}
}

function init(){
	location.reload();
}