package com.example.taylor.cs3270a5;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.CountDownTimer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;
import android.support.v4.app.Fragment;

import java.math.BigDecimal;

public class MainActivity extends AppCompatActivity {

    boolean inGame;
    CountDownTimer ct;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new ChangeResults(), "TO")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.middle, new ChangeButtons(), "MD")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.bottom, new ChangeActions(), "BO")
                .commit();


    }

    public void setInGame(boolean bool){
        inGame = bool;
    }
    public boolean getInGame(){
        return inGame;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        int id = item.getItemId();
        Toast toast;
        switch (id){
            case R.id.btnZeroCorrectCount:
                actions.setCorrectChangeCount(0);
                actions.setCorrectChangeDisplay(actions.getCorrectChangeCount());
                toast = Toast.makeText(this,"Reset To Zero", Toast.LENGTH_SHORT);
                toast.show();
                return true;
            case R.id.btnSetChangeMax:
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.top, new ChangeResults(), "TO")
                        .commit();
                toast = Toast.makeText(this,"Set Maximum", Toast.LENGTH_SHORT);
                toast.show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    //resets the change total so far variable and display to 0
    public void resetGame(){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        results.setChangeTotalSoFar(new BigDecimal("0.00"));
        results.setChangeTotalSoFarDisplay(results.getChangeTotalSoFar());
        results.resetTime();
        results.setTimeDisplay(results.getTimeRemaining());
        setInGame(false);
    }

    public void resetAmount(){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        results.generateAmount();
    }


    public void outOfTime(){
        resetGame();
        TimesUpDialog dialog = new TimesUpDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Times Up Dialog");
    }

    public void correctAmount(){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        resetGame();
        actions.setCorrectChangeCount(actions.getCorrectChangeCount() + 1);
        actions.setCorrectChangeDisplay(actions.getCorrectChangeCount());
        CorrectAmountDialog dialog = new CorrectAmountDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Correct Amount Dialog");
    }

    public void incorrectAmmount(){
        resetGame();
        IncorrectAmountDialog dialog = new IncorrectAmountDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Incorrect Amount Dialog");
    }

    public void startGame(){
        resetGame();
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        startTimer(30);
        setInGame(true);
    }

    public void startTimer(int sec){
        ct = new CountDownTimer(sec * 1000, 1000) {
            ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
            ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
            ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
            public void onTick(long millisUntilFinished) {
                results.setTimeRemaining((int)millisUntilFinished / 1000);
                results.setTimeDisplay(results.getTimeRemaining());
            }

            public void onFinish() {
                results.setTimeDisplay(0);
                outOfTime();
            }
        };
        ct.start();
    }

    public void addToTotal(BigDecimal value){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        results.setChangeTotalSoFar(results.getChangeTotalSoFar().add(value));
        results.setChangeTotalSoFarDisplay(results.getChangeTotalSoFar());
        if(results.getChangeToMake().doubleValue() < results.getChangeTotalSoFar().doubleValue()){
            ct.cancel();
            incorrectAmmount();
        }
        if(results.getChangeToMake().doubleValue() == results.getChangeTotalSoFar().doubleValue()){
            ct.cancel();
            correctAmount();
        }
    }


    @Override
    public void onPause() {
        super.onPause();
        SharedPreferences sp = getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor ed = sp.edit();
        ed.putBoolean("inGame", getInGame());
        ed.apply();
    }

    @Override
    public void onResume() {
        super.onResume();
        SharedPreferences sp = getPreferences(Context.MODE_PRIVATE);
        setInGame(sp.getBoolean("inGame", false));
    }
}
