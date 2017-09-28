package com.example.taylor.cs3270a5;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;
import android.support.v4.app.Fragment;

import java.math.BigDecimal;

public class MainActivity extends AppCompatActivity {
    ChangeResults results;
    ChangeButtons buttons;
    ChangeActions actions;

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

        results = (ChangeResults) getSupportFragmentManager().findFragmentByTag("TO");
        buttons = (ChangeButtons) getSupportFragmentManager().findFragmentByTag("MD");
        actions = (ChangeActions) getSupportFragmentManager().findFragmentByTag("BO");
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
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
                toast = Toast.makeText(this,"Set Maximum", Toast.LENGTH_SHORT);
                toast.show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    //resets the change total so far variable and display to 0
    public void resetGame(){
        results.setChangeTotalSoFar(new BigDecimal("0.0"));
        results.setChangeTotalSoFarDisplay(results.getChangeTotalSoFar());
        results.setTimeRemaining(30);
        results.setTimeDisplay(results.getTimeRemaining());
    }

    public void resetAmount(){
        results.generateAmount();
    }


    public void outOfTime(){
        resetGame();
        TimesUpDialog dialog = new TimesUpDialog();
        dialog.setCancelable(false);
        dialog.show(getSupportFragmentManager(), "Times Up Dialog");
    }

    public void correctAmount(){
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
}
