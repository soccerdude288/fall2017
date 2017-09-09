var randomNum = Math.floor(Math.random() * 101);
$(function(){
	$("#number").text(randomNum);
});


function checkGuess(){
	var value = $("#txtGuess").val();
	if(value > randomNum){
		$("#output2").text("Your guess is too high.");
	}
	else if(value < randomNum){
		$("#output2").text("Your guess is too low.");
	}
	else{
		$("#output2").text("Your guess is correct.");
	}
}

function init(){
	location.reload();
}