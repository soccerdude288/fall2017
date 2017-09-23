package com.taylorearl.cs3270a4;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new TotalsFragment(), "TO")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.middle, new TaxFragment(), "MD")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.bottom, new ItemsFragment(), "BO")
                .commit();
    }
}
