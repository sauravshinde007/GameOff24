INCLUDE globals.ink

{isTalked_sophia == false : -> main | -> already_chose}

=== main ===
You meet Sophia at the café booth.  
Sophia: "Elysia used to sit here all the time. She left something the last time I saw her."  
+ [Ask Sophia to show what Elysia left]  
    ~ isTalked_sophia = true  
    ~ total_points += 5  
    -> sophia_letter  
+ [Ask if Sophia noticed anything unusual about Elysia]  
    ~ isTalked_sophia = true  
    ~ total_points += 3  
    -> sophia_paranoia  
+ [Say you’ll look around yourself]  
    ~ isTalked_sophia = true  
    ~ total_points += 0  
    -> ignored_sophia  

=== sophia_letter ===
Sophia: "She left this letter behind. It’s cryptic, but it might mean something to you."  
Clue Location: Letter at Café Booth  
-> END  

=== sophia_paranoia ===
Sophia: "She always seemed like she was hiding from someone. But I don’t know who. Oh, and here’s the letter she left."  
Clue Location: Letter at Café Booth  
-> END  

=== ignored_sophia ===
Sophia: "Alright. Do whatever you need to."  
-> END  

=== already_chose ===
Sophia: "I gave you the letter. What more do you need?"  
-> END  
