package com.taylorearl.cs3270a3;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity {

    bottom b;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new top(), "TO")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.bottom, new bottom(), "BT")
                .commit();

    }



    public void computerWin(){
        b = (bottom) getSupportFragmentManager().findFragmentByTag("BT");
        b.gamePlayed();
        b.computerWin();
    }

    public void userWin(){
        b = (bottom) getSupportFragmentManager().findFragmentByTag("BT");
        b.gamePlayed();
        b.playerWin();
    }

    public void tieGame(){
        b = (bottom) getSupportFragmentManager().findFragmentByTag("BT");
        b.gamePlayed();
        b.gameTie();
    }
}
