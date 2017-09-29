package com.example.taylor.cs3270a5;


import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;


/**
 * A simple {@link Fragment} subclass.
 */
public class IncorrectAmountDialog extends DialogFragment {


    public IncorrectAmountDialog() {
        // Required empty public constructor
    }


    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        Dialog dialog =
                builder.setMessage("You should try again.")
                        .setCancelable(false)
                        .setTitle("That's too much change.")
                        .setNeutralButton("OK", new DialogInterface.OnClickListener(){
                            public void onClick(DialogInterface dialog, int id){
                                MainActivity ma = (MainActivity) getActivity();
                            }
                        })
                        .create();
        return dialog;
    }

}
