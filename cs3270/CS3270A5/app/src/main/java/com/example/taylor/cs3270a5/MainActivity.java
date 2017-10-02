package com.example.taylor.cs3270a5;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.CountDownTimer;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
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
        Log.d("testing", "in onCreate");
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
        Log.d("testing", "selected option");
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        int id = item.getItemId();
        Toast toast;
        switch (id){
            case R.id.btnZeroCorrectCount:
                Log.d("testing", "selected zero count");
                actions.setCorrectChangeCount(0);
                actions.setCorrectChangeDisplay(actions.getCorrectChangeCount());
                toast = Toast.makeText(this,"Reset To Zero", Toast.LENGTH_SHORT);
                toast.show();
                return true;
            case R.id.btnSetChangeMax:
                Log.d("testing", "selected change max");
                FragmentManager fg = getSupportFragmentManager();
                Fragment setMaxFrag = new SetMaxAmount();
                Fragment resultsFrag = fg.findFragmentByTag("TO");
                Fragment buttonsFrag = fg.findFragmentByTag("MD");
                Fragment actionsFrag = fg.findFragmentByTag("BO");
                fg.beginTransaction().hide(resultsFrag).hide(buttonsFrag)
                        .hide(actionsFrag).replace(R.id.top, setMaxFrag, "MAX")
                        .addToBackStack(null)
                        .commit();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    //resets the change total so far variable and display to 0
    public void resetGame(){
        Log.d("testing", "in resetGame()");
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        results.setChangeTotalSoFar(new BigDecimal("0.00"));
        results.setChangeTotalSoFarDisplay(results.getChangeTotalSoFar());
        if(ct != null)
            ct.cancel();
        results.resetTime();
        results.setTimeDisplay(results.getTimeRemaining());
        setInGame(false);
    }

    public void resetAmount(){
        Log.d("testing", "in resetAmount()");
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        results.generateAmount();
    }


    public void outOfTime(){
        Log.d("testing", "in outOfTime()");
        resetGame();
        TimesUpDialog dialog = new TimesUpDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Times Up Dialog");
    }

    public void correctAmount(){
        Log.d("testing", "in correctAmount");
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
        Log.d("testing", "in incorrectAmount");
        resetGame();
        IncorrectAmountDialog dialog = new IncorrectAmountDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Incorrect Amount Dialog");
    }

    public void startGame(){
        Log.d("testing", "in startGame()");
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        ChangeButtons buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        ChangeActions actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
        results.setChangeTotalSoFar(new BigDecimal("0.00"));
        results.setChangeTotalSoFarDisplay(results.getChangeTotalSoFar());
        startTimer(30);
        setInGame(true);
    }

    public void startTimer(int sec){
        Log.d("testing", "in startTimer()");
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
        Log.d("testing", "in addToTotal()");
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
        Log.d("testing", "in onPause");
        super.onPause();
        SharedPreferences sp = getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor ed = sp.edit();
        ed.putBoolean("inGame", getInGame());
        ed.apply();
        if(ct != null)
            ct.cancel();
    }

    @Override
    public void onResume() {
        Log.d("testing", "in onResume");
        super.onResume();
        SharedPreferences sp = getPreferences(Context.MODE_PRIVATE);
        setInGame(sp.getBoolean("inGame", false));
    }

    public void setMaxAmount(int value){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        results.setMax(new BigDecimal(value));
    }

    public String getMaxAmount(){
        ChangeResults results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        BigDecimal maxD = results.getMax();
        return maxD.toString();
    }
}
