const int LED = 13;

int val = 0;
//int state = 0;
//int LEDstate = 0;

void setup(){
  pinMode(LED,OUTPUT);    //13Pinを出力にする
//  pinMode(BUTTON,INPUT);  //12Pinを入力にする
}
void loop(){
//  digitalWrite(LED,HIGH);
//  delay(1000);
//  digitalWrite(LED,LOW);
//  delay(1000);

    val = analogRead(0);

//    if( == HIGH){
      digitalWrite(LED,HIGH);
      delay(val);
//    }else{
      digitalWrite(LED,LOW);
      delay(val);
//    }
}
