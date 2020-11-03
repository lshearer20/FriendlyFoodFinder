package com.example.friendlyfoodfinder

import android.content.Context
import android.os.Bundle
import com.google.android.material.snackbar.Snackbar
import androidx.appcompat.app.AppCompatActivity;

import kotlinx.android.synthetic.main.activity_create_user.*
import kotlinx.android.synthetic.main.content_create_user.*
import java.io.ByteArrayOutputStream
import java.lang.System.out
import java.net.URL
import android.content.SharedPreferences
import android.R.id.edit
import android.content.Intent
import android.os.StrictMode

class CreateUser : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create_user)
        setSupportActionBar(toolbar)

        button.setOnClickListener { view ->
            val policy = StrictMode.ThreadPolicy.Builder().permitAll().build()
            StrictMode.setThreadPolicy(policy)
            val result = URL("http://friendly-food-finder.azurewebsites.net/api/user/create/"+editText.text.toString()).readText()
            val sharedPreferences = getApplicationContext().getSharedPreferences("Settings", 0);
            val editor = sharedPreferences.edit()
            editor.putString("username", editText.text.toString())
            editor.putString("userID", result.subSequence(1,result.length-1).toString())
            editor.apply()

            var select_allergies_intent = Intent(this, SelectAllergies::class.java)
            startActivity(select_allergies_intent)

            finish()
        }
    }

}
