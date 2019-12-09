<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        
        <style>
            
            .all {
                width: 1900px;
                max-height: 800px;
                margin-left: 150px; 
                margin-top: 8px;
            }
        
            .game {
                display: inline-block;
                
                height: 800px;
                width: 800px;
            }
            
            .view {
                background-color: black;
                display: inline-block;
                position: absolute;
                left: 975px;
                
                vertical-align: top;
                
                height: 800px;
                width: 800px;
                
                visibility: hidden;
            }
            
            .square {
                display: inline-block;
                
                //border: 1px solid white;
                //box-sizing: border-box;
                
                height: 40px;
                width: 40px;
            }
        
        
            
            #backgroundpanel {
                fill: url(#panelgradient);
            }
            
            #backgroundpanel svg {
                fill: url(#panelgradient);
            }
            
            #backgroundceiling {
                fill: url(#ceilinggradient);
            }
            
            #backgroundfloor {
                fill: url(#floorgradient);
            }
            
            #leftwall {
                fill: url(#lwallgradient);
            }
            
            #rightwall {
                fill: url(#rwallgradient);
            }
            
            #leftpilar {
                fill: url(#lpilargradient);
            }
            
            #rightpilar {
                fill: url(#rpilargradient);
            }
            
            #leftlongwall {
                fill: url(#llongwallgradient);
            }
            
            #rightlongwall {
                fill: url(#rlongwallgradient);
            }
            
            #bigwall {
                fill: url(#bigwallgradient);
            }
            
            #bigwallcontent {
                position: relative;
                
                pointer-events: none;
                
                z-index: 1;
                
                margin-top: -100%;
                max-height: 100%;
            }
            
            #bigwallcontent img {
                display: block;
                
                pointer-events: all;
            }
            
            
            #textcontent {
                position: absolute; 
                z-index: 1;
                
                pointer-events: none;
                
                margin-top: -800px;
                height: 30px;
                width: 800px;
                
                text-align: center;
                
                font: 45px "Comic Sans MS";
            }
            
            #textcontent span {
                position: absolute;
                display: block;
                
                width: 60%;
                margin-left: 20%;
                
                text-align: center;
                line-height: 100%;
                
                animation: animation 1.5s linear 1 forwards;
                
            }
            
            @keyframes animation {
                0%   { 
                    transform: translateY(200%);
                    opacity: 100%;
                }
                99% { 
                    transform: translateY(-50%); 
                    opacity: 0%;
                }
                100% { 
                    transform: translateY(-5000%); 
                    opacity: 0%;
                }
            }
            
            
            #compas {
                position: absolute; 
                
                z-index: 1;
                
                top: 12px;
                margin-left: 4px;
                
                height: 100px;
                width: 100px;
            }
            
            #stresshover {
                position: absolute; 
                display: block;
                
                pointer-events: none;
                
                top: 8px;
                
                height: 800px;
                width: 800px;
            }
            
            @keyframes stressanim {
                0%   {
                    opacity: 100%;
                }
                65% { 
                    opacity: 30%;
                }
                95% { 
                    opacity: 30%;
                }
                100% { 
                    opacity: 100%;
                }
            }

            
        
            table tr td {
                border: 0px solid black;
                margin: 0;
                padding: 0;
            }
            
            
            
            table {
                position: absolute;
                
                width: 800px;
                top: 825px;
            }
            
            td {
                width: 75px;
                height: 75px;
            }
            
            button {
                width: 75px;
                height: 75px;
                font-size: 25px;
                line-height: 25px;
                
                border: 2px solid black
            }
            
            .inventory {
                background-color: #BBBBBB;
                
                text-align: center;
                
                border: 4px solid black;
                box-sizing: border-box;
                border-radius: 10px;
            }
            
            .inventory img {
                height: 60px;
            }
            
            #timer {
                position: absolute;
                
                left: 975px;
                margin-top: 10px;
                
                font: 20px "Comic Sans MS";
            }
        
        </style>

    </head>

    <body>
        <div class="all">
            <div class="game">
                <div class="plateing"></div>
                
                <div id="bigwallcontent"></div>
            </div>
            
            <div id="textcontent"><span></span></div>
                
            <div id="compas">
                <svg width="100" height="100">
                    <circle style="fill:#555555" cx="50" cy="50" r="50"/>
                    <circle style="fill:#FFFFFF" cx="50" cy="50" r="46"/>
                    <circle style="fill:#000000" cx="50" cy="50" r="44"/>
                    
                    <text x="45" y="20" font-family="Verdana" font-size="14" style="fill:#FFFFFF">N</text>
                    <text x="10" y="54" font-family="Verdana" font-size="14" style="fill:#FFFFFF">O</text>
                    <text x="45" y="90" font-family="Verdana" font-size="14" style="fill:#FFFFFF">S</text>
                    <text x="80" y="53" font-family="Verdana" font-size="14" style="fill:#FFFFFF">E</text>
                    
                    <polygon id="northArrow" style="fill:#FF0000; visibility: hidden" points="45,55 55,55 50,25" />
                    <polygon id="westArrow" style="fill:#FF0000; visibility: hidden" points="55,45 55,55 25,50" />
                    <polygon id="southArrow" style="fill:#FF0000; visibility: hidden" points="45,45 55,45 50,75" />
                    <polygon id="eastArrow" style="fill:#FF0000; visibility: hidden" points="45,45 45,55 75,50" />
                </svg>
            </div>
            
            <div id="stresshover"></div>
           
            <div class="view"></div>
            <div id="position"></div>
            
            
            <table>
                <tr>
                    <td style="width:auto;"></td>
                    <td class="inventory"><img src="ARX_content/inv_flute.png" style="visibility:hidden; height: 50px;"></td>
                    <td class="inventory"><img src="ARX_content/inv_key.png" style="visibility:hidden"></td>
                    <td class="inventory"><img src="ARX_content/inv_ketchup.png" style="visibility:hidden; transform:rotate(22deg);"></td>
                    
                    <td style="width:auto;"></td>
                    <td><button onclick="turnLeft()">&cularr;</button></td>
                    <td><button style="height:54%;" onclick="goUp()">&uarr;</button><button style="height:46%;" onclick="goDown()">&darr;</button></td>
                    <td><button onclick="turnRight()">&curarr;</button></td>
                    <td style="width:auto;"></td>
                    
                    <td class="inventory"><img src="ARX_content/inv_hammer.png" style="visibility:hidden; transform:rotate(45deg);"></td>
                    <td class="inventory"><img src="ARX_content/inv_sword.png" style="visibility:hidden; transform:rotate(-80deg);"></td>
                    <td class="inventory"><img src="ARX_content/inv_proc.png" style="visibility:hidden"></td>
                    <td style="width:auto;"></td>
                </tr>
            </table>
            
            <div id="timer"><strong>
            </strong></div>
             
        </div>
        
        
    
    </body>
    
    
    
    
    
    
    
    <script>

        var posX = 0;
        var posY = 5;
        var rot = 90;

        var maxI = 20;
        var maxJ = 20;

        var topp = 42;
        var left = 48;
        var right = 52;
        var bottom = 50;

        var hlBack = left+","+topp;
        var hrBack = right+","+topp;
        var dlBack = left+","+bottom;
        var drBack = right+","+bottom;

        var downView = 87;

        var wallLeft = 15;
        var wallRight = 85;

        var hlWall = wallLeft+","+0;
        var dlWall = wallLeft+","+downView;

        var hrWall = wallRight+","+0;
        var drWall = wallRight+","+downView;
        
        var pathColor = "limegreen"
        
        var speedrunStart = 0;
        var speedrunEnd = 0;
        var timerState = 0;

        
        var table = [
            [0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
            [0,0,3,0,4,2,1,3,0,0,0,0,4,1,0,4,2,2,3,0],
            [0,0,4,2,2,2,4,1,0,0,0,0,3,0,4,3,0,3,3,0],
            [0,4,1,0,0,0,3,0,0,0,0,0,3,0,3,2,3,3,3,0],
            [0,3,0,3,0,4,3,0,0,0,0,0,4,4,3,0,2,3,3,0],
            [2,4,2,1,0,2,2,3,0,0,0,0,2,3,2,4,2,2,3,0],
            [0,2,3,0,0,0,4,1,0,0,0,0,0,3,4,2,1,2,4,1],
            [0,0,2,2,4,2,1,0,0,3,0,0,0,4,2,2,3,0,2,3],
            [0,0,0,0,2,1,2,4,2,4,2,4,1,2,1,0,3,4,2,1],
            [0,0,0,0,0,0,0,3,0,3,0,3,0,0,0,0,2,1,0,0],
            [0,0,2,2,1,0,0,4,2,4,2,3,0,0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0,3,0,3,0,3,0,0,0,0,0,0,0,0],
            [0,2,2,4,2,1,2,2,2,4,2,2,1,3,0,4,4,2,1,0],
            [0,0,0,4,2,3,0,0,0,1,0,0,0,3,0,3,4,2,3,0],
            [0,3,0,4,3,2,3,0,0,1,0,0,4,2,2,1,3,0,3,0],
            [0,3,0,3,3,0,4,2,2,1,2,4,3,0,0,0,2,2,3,0],
            [0,4,4,2,3,4,4,3,0,0,0,2,4,3,3,4,2,3,3,0],
            [0,1,3,0,3,1,1,3,0,0,0,0,3,4,2,3,3,2,4,1],
            [0,0,2,2,2,2,2,1,0,0,0,0,4,3,0,2,4,2,1,0],
            [0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0]
        ];
        
        var box = 
        `<svg width="40" height="40">
            <rect class="hl" style="fill:black" x="0"  y="0"  width="14" height="14" />
            <rect class="hm" style="fill:black" x="13" y="0"  width="15" height="14" />
            <rect class="hr" style="fill:black" x="27" y="0"  width="14" height="14" />
            <rect class="ml" style="fill:black" x="0"  y="13" width="14" height="15" />
            <rect class="mm" style="fill:black" x="13" y="13" width="15" height="15" />
            <rect class="mr" style="fill:black" x="27" y="13" width="14" height="15" />
            <rect class="dl" style="fill:black" x="0"  y="27" width="14" height="14" />
            <rect class="dm" style="fill:black" x="13" y="27" width="15" height="14" />
            <rect class="dr" style="fill:black" x="27" y="27" width="14" height="14" />
        </svg>`;
        
        
        //Create map
        for(var i = 0; i < maxI; i++)
        {
            for(var j = 0; j < maxJ; j++)
            {
                let square = document.createElement("div");
                square.className = "square";
                let thisbox = box;
                square.innerHTML = thisbox;

                let indexI = i;
                let indexJ = j;

                display(indexI, indexJ, square);

                document.getElementsByClassName("view")[0].appendChild(square);

                /*square.onclick = function()
                {
                    if(table[indexI][indexJ] == 0)
                    {
                        table[indexI][indexJ] = 1;
                    }
                    else if(table[indexI][indexJ] == 1)
                    {
                        table[indexI][indexJ] = 2;
                    }
                    else if(table[indexI][indexJ] == 2)
                    {
                        table[indexI][indexJ] = 3;
                    }
                    else if(table[indexI][indexJ] == 3)
                    {
                        table[indexI][indexJ] = 4;
                    }
                    else if(table[indexI][indexJ] == 4)
                    {
                        table[indexI][indexJ] = 0;
                    }

                    display(indexI, indexJ, square);

                    if(indexI+1 < maxI)
                    {
                        display(indexI+1, indexJ);
                    }

                    if(indexJ+1 < maxJ)
                    {
                        display(indexI, indexJ+1);
                    }
                }*/
            }
            document.getElementsByClassName("view")[0].insertAdjacentHTML("beforeend", "<br>");
        }


        //Create pointer
        displayPoint();

        
        //Render view
        displayView();
        
        displayWallContent();
        
        
        //Keyboard events
        var keyFlag = false;
        window.addEventListener("keydown", function(event) 
        {
            switch(event.code) {
                case "KeyW":
                case "ArrowUp":
                case "Numpad8":
                    //moveTo("up");
                    goUp();
                    break;
                    
                case "KeyS":
                case "ArrowDown":
                case "Numpad2":
                    //moveTo("down");
                    goDown();
                    break;
                    
                case "KeyA":
                case "ArrowLeft":
                case "Numpad4":
                    //moveTo("left");
                    turnLeft();
                    break;
                    
                case "KeyD":
                case "ArrowRight":
                case "Numpad6":
                    //moveTo("right");
                    turnRight();
                    break;
                    
                case "F5":
                    location.reload();
                    break;
            }
                    
            event.preventDefault();
        }, true);
        
        

        function map(x, in_min, in_max, out_min, out_max) 
        {
          return (x-in_min) * (out_max-out_min) / (in_max-in_min)+out_min;
        }
        
        
        //Timer gestion
        function updateTimer()
        {
            if(timerState == 0)
            {
                let date = new Date().getTime();
                speedrunStart = date;
                speedrunEnd = date;
                
                timerState = 1;
            }
            else if(timerState == 1)
            {
                speedrunEnd = new Date().getTime();
            }
                
            document.getElementById("timer").textContent = "Temps : " + (speedrunEnd-speedrunStart);
        }
        
        
        //Movement gestion
        function moveTo(wantTo)
        {
            if((wantTo == "up" && rot == 0) ||
               (wantTo == "right" && rot == 90) ||
               (wantTo == "down" && rot == 180) ||
               (wantTo == "left" && rot == 270))
            {
                goUp();
            }
            
            else if((wantTo == "up" && rot == 180) ||
                    (wantTo == "right" && rot == 270) ||
                    (wantTo == "down" && rot == 0) ||
                    (wantTo == "left" && rot == 90))
            {
                if(goDown() == false)
                {
                    turnLeft();
                    turnLeft();
                }
            }
            
            else if((wantTo == "up" && rot == 90) ||
                    (wantTo == "right" && rot == 180) ||
                    (wantTo == "down" && rot == 270) ||
                    (wantTo == "left" && rot == 0))
            {
                turnLeft();
            }
            
            else if((wantTo == "up" && rot == 270) ||
                    (wantTo == "right" && rot == 0) ||
                    (wantTo == "down" && rot == 90) ||
                    (wantTo == "left" && rot == 180))
            {
                turnRight();
            }
        }

        
        //Change player orientation to left
        function turnLeft()
        {
            rot = (rot+270)%360;
                walk();

            displayPoint();
            displayView();
            updateTimer();
        }

        
        //Change player orientation to right
        function turnRight()
        {
            rot = (rot+90)%360;
                walk();

            displayPoint();
            displayView();
            updateTimer();
        }


        //Advance player if possible 
        function goUp()
        {
            if(rot == 0 && posY > 0 && (table[posY-1][posX] == 3 || table[posY-1][posX] == 4) && table[posY-1][posX] != 0)
            {
                posY -= 1;
                walk();
            }
            else if(rot == 90 && posX < maxJ && (table[posY][posX] == 2 || table[posY][posX] == 4) && table[posY][posX+1] != 0)
            {
                posX += 1;
                walk();
            }
            else if(rot == 180 && posY < maxI && (table[posY][posX] == 3 || table[posY][posX] == 4) && table[posY+1][posX] != 0)
            {
                posY += 1;
                walk();
            }
            else if(rot == 270 && posX > 0 && (table[posY][posX-1] == 2 || table[posY][posX-1] == 4) && table[posY][posX-1] != 0)
            {
                posX -= 1;
                walk();
            }

            displayPoint();
            displayView();
            updateTimer();
        }
        
        
        //Step back player if possible 
        function goDown()
        {
            if(rot == 0 && posY < maxJ && (table[posY][posX] == 3 || table[posY][posX] == 4) && table[posY+1][posX] != 0)
            {
                posY += 1;
                walk();
            }
            else if(rot == 90 && posX > 0 && (table[posY][posX-1] == 2 || table[posY][posX-1] == 4) && table[posY][posX-1] != 0)
            {
                posX -= 1;
                walk();
            }
            else if(rot == 180 && posY > 0 && (table[posY-1][posX] == 3 || table[posY-1][posX] == 4) && table[posY-1][posX] != 0)
            {
                posY -= 1;
                walk();
            }
            else if(rot == 270 && posX < maxI && (table[posY][posX] == 2 || table[posY][posX] == 4) && table[posY][posX+1] != 0)
            {
                posX += 1;
                walk();
            }
            else
            {
                return false;
            }

            displayPoint();
            displayView();
            updateTimer();
        }


        //Decide which wall to render
        function displayView()
        {
            var pathLeft = false;
            var pathRight = false;
            var pathFront = false;

            if(rot == 0)
            {
                if(posX > 0 && (table[posY][posX-1] == 2 || table[posY][posX-1] == 4))
                {
                    pathLeft = true;
                }
                if(table[posY][posX] == 2 || table[posY][posX] == 4)
                {
                    pathRight = true;
                }
                if(posY > 0 && (table[posY-1][posX] == 3 || table[posY-1][posX] == 4))
                {
                    pathFront = true;
                }
            }
            else if(rot == 90)
            {
                if(posY > 0 && (table[posY-1][posX] == 3 || table[posY-1][posX] == 4))
                {
                    pathLeft = true;
                }
                if(table[posY][posX] == 3 || table[posY][posX] == 4)
                {
                    pathRight = true;
                }
                if(table[posY][posX] == 2 || table[posY][posX] == 4)
                {
                    pathFront = true;
                }
            }
            else if(rot == 180)
            {
                if(table[posY][posX] == 2 || table[posY][posX] == 4)
                {
                    pathLeft = true;
                }
                if(posX > 0 && (table[posY][posX-1] == 2 || table[posY][posX-1] == 4))
                {
                    pathRight = true;
                }
                if(table[posY][posX] == 3 || table[posY][posX] == 4)
                {
                    pathFront = true;
                }
            }
            else if(rot == 270)
            {
                if(table[posY][posX] == 3 || table[posY][posX] == 4)
                {
                    pathLeft = true;
                }
                if(posY > 0 && (table[posY-1][posX] == 3 || table[posY-1][posX] == 4))
                {
                    pathRight = true;
                }
                if(posX > 0 && (table[posY][posX-1] == 2 || table[posY][posX-1] == 4))
                {
                    pathFront = true;
                }
            }

            displayGame(pathLeft,pathRight,pathFront);
        }
        
        
        function walk()
        {
            var upScale = Math.floor(Math.random() * 10);
            var rightScale = Math.floor(Math.random() * 16)-8;
            
            document.getElementsByClassName("game")[0].style.marginTop = upScale+"px";
            document.getElementById("stresshover").style.top = (upScale+8)+"px";
            
            document.getElementsByClassName("game")[0].style.marginLeft = rightScale+"px";
            document.getElementById("stresshover").style.marginLeft = rightScale+"px";
            
            setTimeout(function(){
                document.getElementsByClassName("game")[0].style.marginTop = "0px";
                document.getElementById("stresshover").style.top = "8px";
                
                document.getElementsByClassName("game")[0].style.marginLeft = "0px";
                document.getElementById("stresshover").style.marginLeft = "0px";
            }, 100);
        }
        
        
        //Display content on plain wall
        function displayWallContent()
        {
            //Rock 1 1 on ground
            if(posX == 1 && posY == 5 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "90% 82% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 1 2 on ground
            else if(posX == 1 && posY == 5 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 0 0 45%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 1 3 on ground
            else if(posX == 1 && posY == 5 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "90% 0 0 82%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 2 1 on ground
            else if(posX == 1 && posY == 4 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 45% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 3 1 on ground
            else if(posX == 1 && posY == 3 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "90% 0 0 55%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 3 2 on ground
            else if(posX == 1 && posY == 3 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 45% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 4 1 on ground
            else if(posX == 2 && posY == 3 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "90% 55% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 4 2 on ground
            else if(posX == 2 && posY == 3 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 0 0 45%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 5 1 on ground
            else if(posX == 2 && posY == 2 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 45% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 5 2 on ground
            else if(posX == 2 && posY == 2 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "90% 0 0 65%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            //Rock 6 1 on ground
            else if(posX == 2 && posY == 1 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "80% 0 0 45%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/rocky.png' height='3%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    displayText("Un caillou ?");'>`;
            }
            
            
            //Map on ground
            else if(posX == 2 && posY == 0 && rot == 0 && 
                    document.getElementsByClassName("view")[0].style.visibility == "")
            {
                document.getElementById("bigwallcontent").style.padding = "15% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/map.png' height='42%' style='margin:auto; transform:rotate(-10deg);' 
                    onclick='
                    document.getElementsByClassName("view")[0].style.visibility = "visible";
                    displayView();
                    displayText("Vous ramassez la carte !");'>`;
            }
            
            
            //Poke ball on ground
            else if(posX == 3 && posY == 4 && rot == 0 && 
                    document.getElementsByClassName("inventory")[0].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "79% 0 0 69%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_flute.png' height='10%' style='margin:auto; transform:rotate(-20deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[0].firstChild.style.visibility = "visible"; 
                    displayView();
                    display(posY,posX);
                    displayText("Vous ramassez la pok&eacute; flute");'>`;
            }
            //Ronflex wall
            else if(posX == 5 && posY == 8 && rot == 90 && table[8][5] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "30% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/ronflex.png' height='60%' style='margin:auto;'
                    onclick='
                    if(document.getElementsByClassName("inventory")[0].firstChild.style.visibility == "visible"){
                        table[8][5] = 2; 
                        display(8,5); 
                        display(8,6); 
                        displayView();
                        displayText("Vous réveillez le ronflex");
                        document.getElementById("stresshover").style.backgroundColor = "rgba(255,0,0,0.15)"; 
                    }else{displayText("Il faudrait une pok&eacute; flute");}'>`;
            }
            
            
            //Red key wall
            else if(posX == 7 && posY == 11 && rot == 270 && 
                    document.getElementsByClassName("inventory")[1].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "35% 45% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_key.png' height='5%' style='margin:auto; transform:rotate(-45deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[1].firstChild.style.visibility = "visible"; 
                    displayView();
                    display(posY,posX);
                    displayText("Vous ramassez la clé rouge");'>`;
            }
            //Red door
            else if(posX == 6 && posY == 12 && rot == 270 && table[12][5] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/red_door.png' height='87%' style='margin:auto' 
                    onclick='
                    if(document.getElementsByClassName("inventory")[1].firstChild.style.visibility == "visible"){
                        table[12][5] = 2; 
                        display(12,5); 
                        display(12,6); 
                        displayView();
                        displayText("La porte rouge s&#39;ouvre");
                    }else{displayText("Il faut la clé rouge");}'>`;
            }
            
            
            //Ketchup wall
            else if(posX == 1 && posY == 17 && rot == 180 && 
                    document.getElementsByClassName("inventory")[2].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "80% 65% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_ketchup.png' height='12%' style='margin:auto;' 
                    onclick='
                    document.getElementsByClassName("inventory")[2].firstChild.style.visibility = "visible"; 
                    displayView();
                    display(posY,posX);
                    displayText("Vous ramassez le ketchup");'>`;
            }
            //Sans wall
            else if(posX == 12 && posY == 8 && rot == 90 && table[8][12] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "23% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/sans.png' height='65%' style='margin:auto' 
                    onclick='
                    if(document.getElementsByClassName("inventory")[2].firstChild.style.visibility == "visible"){
                        table[8][12] = 2; 
                        display(8,12); 
                        display(8,13); 
                        displayView();
                        displayText("Merci");
                    }else{displayText("Vous avez pas du ketchup ?");}'>`;
            }
            
            
            //Hammer right wall
            else if(posX == 5 && posY == 18 && rot == 90 && 
                    document.getElementsByClassName("inventory")[3].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "50% 0 0 10%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_hammer.png' height='6%' style='margin:auto; transform:rotate(-160deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[3].firstChild.style.visibility = "visible"; 
                    displayView();
                    displayText("Vous ramassez le marteau");'>`;
            }
            //Hammer left wall
            else if(posX == 6 && posY == 18 && rot == 270 && 
                    document.getElementsByClassName("inventory")[3].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "50% 10% 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_hammer.png' height='6%' style='margin:auto; transform:rotate(160deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[3].firstChild.style.visibility = "visible"; 
                    displayView();
                    displayText("Vous ramassez le marteau");'>`;
            }
            
            //Crack right wall
            else if(posX == 9 && posY == 15 && rot == 90 && table[15][9] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "2% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/crack.png' height='82%' style='margin:auto' 
                    onclick='
                    if(document.getElementsByClassName("inventory")[3].firstChild.style.visibility == "visible"){
                        table[15][9] = 2; 
                        display(15,9); 
                        display(15,10); 
                        displayView();
                        display(posY,posX);
                        displayText("Vous cassez le mur");
                        document.getElementById("stresshover").style.backgroundColor = "rgba(255,0,0,0.40)"; 
                        document.getElementById("stresshover").style.animation = "stressanim 5s linear infinite";
                    }else{displayText("Il faudrait un marteau");}'>`;
            }
            //Crack left wall
            else if(posX == 10 && posY == 15 && rot == 270 && table[15][9] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "2% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/crack.png' height='82%' style='margin:auto' 
                    onclick='
                    if(document.getElementsByClassName("inventory")[3].firstChild.style.visibility == "visible"){
                        table[15][9] = 2; 
                        display(15,9); 
                        display(15,10); 
                        displayView();
                        displayText("Vous cassez le mur");
                        document.getElementById("stresshover").style.backgroundColor = "rgba(255,0,0,0.40)"; 
                        document.getElementById("stresshover").style.animation = "stressanim 5s linear infinite";
                    }else{displayText("Il faudrait un marteau");}'>`;
            }
            
            
            //Sword wall
            else if(posX == 16 && posY == 6 && rot == 90 && 
                    document.getElementsByClassName("inventory")[4].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "52% 0 0 65%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_sword.png' height='38%' style='margin:auto; transform:rotate(75deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[4].firstChild.style.visibility = "visible"; 
                    displayView();
                    display(posY,posX);
                    displayText("Vous ramassez l&#39;épée");'>`;
            }
            //IE wall
            else if(posX == 12 && posY == 12 && rot == 90 && table[12][12] != 2)
            {
                document.getElementById("bigwallcontent").style.padding = "23% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/internet_explorer.png' height='50%' style='margin:auto' 
                    onclick='
                    if(document.getElementsByClassName("inventory")[4].firstChild.style.visibility == "visible"){
                        table[12][12] = 2; 
                        display(12,12); 
                        display(12,13); 
                        displayView();
                        displayText("Merci");
                        document.getElementById("stresshover").style.backgroundColor = "rgba(255,0,0,0.40)"; 
                        document.getElementById("stresshover").style.animation = "stressanim 5s linear infinite";
                    }else{displayText("Il faudrait au moins une épée");}'>`;
            }
            
            //Proc wall
            else if(posX == 14 && posY == 16 && rot == 0 && 
                    document.getElementsByClassName("inventory")[5].firstChild.style.visibility == "hidden")
            {
                document.getElementById("bigwallcontent").style.padding = "76% 0 0 20%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/inv_proc.png' height='15%' style='margin:auto; transform:rotateX(25deg);' 
                    onclick='
                    document.getElementsByClassName("inventory")[5].firstChild.style.visibility = "visible"; 
                    displayView();
                    display(posY,posX);
                    displayText("Vous ramassez le processeur");'>`;
            }
            //Proc door wall
            else if(posX == 9 && posY == 7 && rot == 0 && table[6][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "40% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/proc_door.png' height='8%' style='margin:auto;'
                    onclick='
                    if(document.getElementsByClassName("inventory")[5].firstChild.style.visibility == "visible"){
                        table[6][9] = 3; 
                        display(6,9); 
                        display(7,9); 
                        displayView();
                        document.getElementById("stresshover").style.backgroundColor = "rgba(0,0,0,0)"; 
                        document.getElementById("stresshover").style.animation = "";
                        displayText("La porte informatique s&#39;ouvre");
                    }else{displayText("Il faudrait un processeur");}'>`;
            }
            
            //Green door 1 on wall
            else if(posX == 9 && posY == 6 && rot == 0 && table[5][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/green_door.png' height='87%' style='margin:auto;' 
                    onclick='
                    let answer = prompt("Oh... à ce que je vois vous avez réussi à arriver jusqu&#39;a moi.\\nBon, je vais vous soumettre un petit quiz pour voir si vous êtes bel et bien digne de passer.\\nRépondez juste par A, B, C ou D.\\n\\nQui est la personne la plus importante de ce monde ?\\nA: Le développeur de ce jeu\\nB: ..\\nC: ..\\nD: ..");

                    if(answer == "A" || answer == "a")
                    {
                        table[5][9] = 3;
                        display(5,9); 
                        display(6,9); 
                        displayView();
                        displayText("Vous pouvez avancer");
                    }
                    else
                    {
                        displayText("Mauvaise réponse");
                    }
                    '>`;
            }
            
            //Green door 2 on wall
            else if(posX == 9 && posY == 5 && rot == 0 && table[4][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/green_door.png' height='87%' style='margin:auto;' 
                    onclick='
                    let answer = prompt("Bien vous avez compris le concept du quiz!\\nCommençons le vrai quiz.\\n\\nAvec quel language ce jeu a t-il été codé ?\\nA: Le HTML\\nB: L&#39;Assembleur\\nC: Le Javascript\\nD: Le C");

                    if(answer == "C" || answer == "c")
                    {
                        table[4][9] = 3;
                        display(4,9); 
                        display(5,9); 
                        displayView();
                        displayText("Vous pouvez avancer");
                    }
                    else
                    {
                        displayText("Mauvaise réponse");
                    }
                    '>`;
            }
            
            //Green door 3 on wall
            else if(posX == 9 && posY == 4 && rot == 0 && table[3][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/green_door.png' height='87%' style='margin:auto;' 
                    onclick='
                    let answer = prompt("Qu&#39;est-ce que le binaire ?\\nA: Un genre\\nB: Un truc avec des chiffres, non ?\\nC: Un ensemble de nerfs\\nD: La base 2");

                    if(answer == "D" || answer == "d")
                    {
                        table[3][9] = 3;
                        display(3,9); 
                        display(4,9); 
                        displayView();
                        displayText("Vous pouvez avancer");
                    }
                    else
                    {
                        displayText("Mauvaise réponse");
                    }
                    '>`;
            }
            
            //Green door 4 on wall
            else if(posX == 9 && posY == 3 && rot == 0 && table[2][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/green_door.png' height='87%' style='margin:auto;' 
                    onclick='
                    let answer = prompt("Quel est la meilleure solution quand quelque chose ne va pas ?\\nA: Chercher une solution sur internet\\nB: Réessayer la même chose\\nC: Éteindre et rallumer\\nD: Acheter un mac");

                    if(answer == "C" || answer == "c")
                    {
                        table[2][9] = 3;
                        display(2,9); 
                        display(3,9); 
                        displayView();
                        displayText("Vous pouvez avancer");
                    }
                    else
                    {
                        displayText("Mauvaise réponse");
                    }
                    '>`;
            }
            
            //Final button on wall
            else if(posX == 9 && posY == 2 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "45% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/red_button.png' height='20%' style='margin:auto;' 
                    onclick='
                        document.getElementById("textcontent").getElementsByTagName("span")[0].style.animation = "animation 7s linear 1 forwards";
                        displayText("Fin du jeu<br><br>Merci beaucoup d&#39;avoir joué");

                        timerState = 2;
                        updateTimer();
                    '>`;
            }
            
            
            
            //Door wall
            else if(posX == 9 && posY == 13 && rot == 180 && table[13][9] != 3)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/door.png' height='87%' style='margin:auto;'
                    onclick='
                        table[13][9] = 3; 
                        display(13,9); 
                        display(14,9); 
                        displayView();
                        displayText("Vous ouvrez la porte");'>`;
            }
            
            //Dog wall
            else if(posX == 9 && posY == 14 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "10% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/dog.gif' height='75%' style='margin:auto;'
                    onclick='displayText("...");'>`;
            }
            
            //Wally on wall
            else if(posX == 1 && posY == 14 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "16% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/wally.png' height='75%' style='margin:auto;'
                    onclick='displayText("Trouvé");'>`;
            }
            
            //Cake is a lie on wall
            else if(posX == 12 && posY == 19 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "15% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/cakeisalie.png' width='55%' style='margin:auto;'
                    onclick='displayText("...");'>`
            }
            
            //Nyan cat on wall
            else if(posX == 6 && posY == 1 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 4%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/nyan_cat.png' width='73%' style='margin:auto;'
                    onclick='displayText("...");'>`
            }
            
            //Potato on wall
            else if(posX == 18 && posY == 1 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "13% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/potato.png' width='50%' style='margin:auto;'
                    onclick='displayText("La patate vous salue");'>`
            }
            
            //Thanos on up wall
            else if(posX == 9 && posY == 10 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "12% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/thanos.png' width='40%' style='margin:auto;'
                    onclick='displayText("*Snap*");'>`
            }
            //Thanos on right wall
            else if(posX == 9 && posY == 10 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "12% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/thanos.png' width='40%' style='margin:auto;'
                    onclick='displayText("*Snap*");'>`
            }
            //Thanos on down wall
            else if(posX == 9 && posY == 10 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "12% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/thanos.png' width='40%' style='margin:auto;'
                    onclick='displayText("*Snap*");'>`
            }
            //Thanos on left wall
            else if(posX == 9 && posY == 10 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "12% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/thanos.png' width='40%' style='margin:auto;'
                    onclick='displayText("*Snap*");'>`
            }
            
            //Night king on wall
            else if(posX == 17 && posY == 2 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "18% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/night_king.png' width='36%' style='margin:auto;'
                    onclick='displayText("Par la glace soyez purifié");'>`
            }
            
            //Grievous on wall
            else if(posX == 16 && posY == 17 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "22% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/grievous.png' width='68%' style='margin:auto;'
                    onclick='displayText("Hello there");'>`
            }
            
            //Palako on wall
            else if(posX == 19 && posY == 17 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "64% 0 0 35%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/palako.png' width='36%' style='margin:auto;'
                    onclick='displayText("PALAKOOOO");'>`
            }
            
            //Temmie on wall
            else if(posX == 3 && posY == 5 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "23% 0 0 10%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/temmie.png' width='60%' style='margin:auto;'
                    onclick='displayText("SAluUt !¡!");'>`
            }
            
            //Waluigi on wall
            else if(posX == 5 && posY == 17 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "24% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/waluigi.png' width='84%' style='margin:auto;'
                    onclick='displayText("Yahoo !");'>`
            }
            
            
            //Blue portal on wall
            else if(posX == 16 && posY == 19 && rot == 180)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/portal_blue.png' width='100%' style='margin:auto;'
                    onclick='
                    posX=2;
                    posY=10;
                    rot=90;
                    displayView();
                    displayPoint();'>`
            }
            //Orange portal on wall
            else if(posX == 2 && posY == 10 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/portal_orange.png' width='100%' style='margin:auto;'
                    onclick='
                    posX=16;
                    posY=19;
                    rot=0;
                    displayView();
                    displayPoint();'>`
            }
            
            //Taboo on wall
            else if(posX == 4 && posY == 10 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "15% 0 0 5%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/taboo.png' width='70%' style='margin:auto;'
                    onclick='displayText("...")'>`
            }
            
            //Kirby on wall
            else if(posX == 13 && posY == 1 && rot == 90)
            {
                document.getElementById("bigwallcontent").style.padding = "70% 0 0 50%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/kirby.png' width='55%' style='margin:auto;'
                    onclick='displayText("Ding-Ding")'>`
            }
            
            //Window on wall
            else if(posX == 7 && posY == 1 && rot == 0)
            {
                document.getElementById("bigwallcontent").style.padding = "4% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/window.png' width='75%' style='margin:auto;'
                    onclick='displayText("Pas une sortie")'>`
            }
            
            //Window on wall
            else if(posX == 1 && posY == 12 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "14% 0 0 10%";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/space.png' width='50%' style='margin:auto;'
                    onclick='displayText("Pas une sortie")'>`
            }
            
            //Servers on wall
            else if(posX == 17 && posY == 6 && rot == 270)
            {
                document.getElementById("bigwallcontent").style.padding = "22% 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = 
                    `<img src='ARX_content/servers.png' width='95%' style='margin:auto; transform:rotateY(18deg);'
                    onclick='displayText("C&#39;est sûrement important")'>`
            }
            

            
            
            else
            {
                document.getElementById("bigwallcontent").style.padding = "0 0 0 0";
                document.getElementById("bigwallcontent").innerHTML = "<img src='ARX_content/empty.png' height='3%'>";
            }
        }

        
        //Display some text on screen
        function displayText(textOnScreen)
        {
            var usedScroll = document.getElementById("textcontent").getElementsByTagName("span")[0];
            var newScroll = usedScroll.cloneNode(true);
            newScroll.innerHTML = textOnScreen;
            usedScroll.parentNode.replaceChild(newScroll, usedScroll);
        }

        
        //Create view's svg with gradients
        function displayGame(turnLeft, turnRight, goFront)
        {   
            var leftLong;
            var leftShort;

            var rightLong;
            var rightShort;


            if(turnLeft == true)
            {
                leftLong = "hidden";
                leftShort = "visible";
            }
            else
            {
                leftLong = "visible";
                leftShort = "hidden";
            }

            if(turnRight == true)
            {
                rightLong = "hidden";
                rightShort = "visible";
            }
            else
            {
                rightLong = "visible";
                rightShort = "hidden";
            }

            if(goFront == true)
            {
                goFront = "hidden";
            }
            else
            {
                goFront = "visible";
            }

            var laby = 
            `<svg viewbox="0 0 100 100">

                <defs>
                    <linearGradient id="panelgradient"
                         x1="0" y1="100%" x2="0" y2="0">
                        <stop offset="0%" stop-color="#000000" />
                        <stop offset="70%" stop-color="#000000" />
                    </linearGradient>

                    <linearGradient id="ceilinggradient"
                         x1="0" y1="100%" x2="0" y2="0">
                        <stop offset="0%" stop-color="#444444" />
                        <stop offset="100%" stop-color="#CCCCCC" />
                    </linearGradient>

                    <linearGradient id="floorgradient"
                         x1="0" y1="100%" x2="0" y2="0">
                        <stop offset="0%" stop-color="#AAAAAA" />
                        <stop offset="100%" stop-color="#333333" />
                    </linearGradient>


                    <linearGradient id="lwallgradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#CCCCCC" />
                        <stop offset="100%" stop-color="#555555" />
                    </linearGradient>

                    <linearGradient id="rwallgradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#555555" />
                        <stop offset="100%" stop-color="#CCCCCC" />
                    </linearGradient>


                    <linearGradient id="lpilargradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#999999" />
                        <stop offset="100%" stop-color="#AAAAAA" />
                    </linearGradient>

                    <linearGradient id="rpilargradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#AAAAAA" />
                        <stop offset="100%" stop-color="#999999" />
                    </linearGradient> 


                    <linearGradient id="llongwallgradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#DDDDDD" />
                        <stop offset="100%" stop-color="#666666" />
                    </linearGradient>

                    <linearGradient id="rlongwallgradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#666666" />
                        <stop offset="100%" stop-color="#DDDDDD" />
                    </linearGradient>


                    <linearGradient id="bigwallgradient"
                         x1="0" y1="0" x2="100%" y2="0">
                        <stop offset="0%" stop-color="#AAAAAA" />
                        <stop offset="20%" stop-color="#CCCCCC" />
                        <stop offset="80%" stop-color="#CCCCCC" />
                        <stop offset="100%" stop-color="#AAAAAA" />
                    </linearGradient>


                </defs>

                <polygon id="backgroundpanel" points="`+hlBack+" "+hrBack+" "+drBack+" "+dlBack+`" width="100" height="100" onclick="goUp();" />

                <polygon id="backgroundceiling" points="0,0 100,0 100,`+topp+" 0,"+topp+`" width="100" height="100" />

                <polygon id="backgroundfloor" points="`+"0,"+bottom+" 100,"+bottom+" 100,100 0,100"+`" width="100" height="100" />



                <polygon id="leftwall" points="`+hlWall+" "+hlBack+" "+dlBack+" "+dlWall+`" width="100" height="100" visibility="`+leftShort+`" />

                <polygon id="rightwall" points="`+hrWall+" "+hrBack+" "+drBack+" "+drWall+`" width="100" height="100" visibility="`+rightShort+`" />



                <polygon id="leftpilar" points="`+"0,0 "+hlWall+" "+dlWall+" 0,"+downView+`" width="100" height="100" visibility="`+leftShort+`" onclick="turnLeft();" />

                <polygon id="rightpilar" points="`+"100,0 "+hrWall+" "+drWall+" 100,"+downView+`" width="100" height="100" visibility="`+rightShort+`" onclick="turnRight();" />



                <polygon id="leftlongwall" points="0,0 `+wallLeft+",0 "+hlBack+" "+dlBack+" "+(left-((left-wallLeft)/((downView-bottom)/(100-bottom))))+",100"+` 0,100" width="100" height="100" visibility="`+leftLong+`" onclick="turnLeft();" />

                <polygon id="rightlongwall" points="100,0 `+wallRight+",0 "+hrBack+" "+drBack+" "+((wallRight-right)/((downView-bottom)/(100-bottom))+right)+",100"+` 100,100" width="100" height="100" visibility="`+rightLong+`" onclick="turnRight();" />



                <polygon id="bigwall" points="`+hlWall+" "+hrWall+" "+drWall+" "+dlWall+`" width="100" height="100" visibility="`+goFront+`" />

                <!--<text id="bigwall" x="5" y="50" style="font:45px; fill:red">!</text>-->
            </svg>`;

            let plate = document.createElement("div");
            plate.className = "plateing";
            let thislaby = laby;
            plate.innerHTML = thislaby;

            document.getElementsByClassName("game")[0].replaceChild(plate, document.getElementsByClassName("plateing")[0]);
            
            displayWallContent();
        }
    
    
        //Display position's arrow on map
        function displayPoint()
        {
            document.getElementById("position").remove();

            if(rot == 0)
            {
                document.getElementsByClassName("square")[(posY*maxI)+posX].getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend", '<polygon id="position" style="fill:red" points="20,10 12,29 28,29" />');
                
                document.getElementById("northArrow").style.visibility = "visible";
                document.getElementById("westArrow").style.visibility = "hidden";
                document.getElementById("southArrow").style.visibility = "hidden";
                document.getElementById("eastArrow").style.visibility = "hidden";
            }
            else if(rot == 90)
            {
                document.getElementsByClassName("square")[(posY*maxI)+posX].getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend", '<polygon id="position" style="fill:red" points="30,20 11,12 11,28" />');
                
                document.getElementById("northArrow").style.visibility = "hidden";
                document.getElementById("westArrow").style.visibility = "visible";
                document.getElementById("southArrow").style.visibility = "hidden";
                document.getElementById("eastArrow").style.visibility = "hidden";
            }
            else if(rot == 180)
            {
                document.getElementsByClassName("square")[(posY*maxI)+posX].getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend", '<polygon id="position" style="fill:red" points="20,30 12,11 28,11" />');
                
                document.getElementById("northArrow").style.visibility = "hidden";
                document.getElementById("westArrow").style.visibility = "hidden";
                document.getElementById("southArrow").style.visibility = "visible";
                document.getElementById("eastArrow").style.visibility = "hidden";
            }
            else if(rot == 270)
            {
                document.getElementsByClassName("square")[(posY*maxI)+posX].getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend", '<polygon id="position" style="fill:red" points="10,20 29,12 29,28" />');
                
                document.getElementById("northArrow").style.visibility = "hidden";
                document.getElementById("westArrow").style.visibility = "hidden";
                document.getElementById("southArrow").style.visibility = "hidden";
                document.getElementById("eastArrow").style.visibility = "visible";
            }

        }


        //Render specific map case
        function display(ii, jj, theSquare = null)
        {
            let thisSquare;
            if(theSquare == null)
            {
                thisSquare = document.getElementsByClassName("square")[((ii)*maxI)+jj];
            }
            else
            {
                thisSquare = theSquare;
            }
            
            thisSquare.getElementsByClassName("hl")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("hm")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("hr")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("ml")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("mm")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("mr")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("dl")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("dm")[0].style["fill"] = "black";
            thisSquare.getElementsByClassName("dr")[0].style["fill"] = "black";
            
            if(table[ii][jj] != 0)
            {
                thisSquare.getElementsByClassName("mm")[0].style["fill"] = pathColor;
            }

            if(table[ii][jj] == 2)
            {
                thisSquare.getElementsByClassName("mr")[0].style["fill"] = pathColor;
            }
            else if(table[ii][jj] == 3)
            {
                thisSquare.getElementsByClassName("dm")[0].style["fill"] = pathColor;
            }
            else if(table[ii][jj] == 4)
            {
                thisSquare.getElementsByClassName("mr")[0].style["fill"] = pathColor;
                thisSquare.getElementsByClassName("dm")[0].style["fill"] = pathColor;
            }

            if(jj > 0 && table[ii][jj] != 0 && (table[ii][jj-1] == 2 || table[ii][jj-1] == 4))
            {
                thisSquare.getElementsByClassName("ml")[0].style["fill"] = pathColor;
            }

            if(ii > 0 && table[ii][jj] != 0 && (table[ii-1][jj] == 3 || table[ii-1][jj] == 4))
            {
                thisSquare.getElementsByClassName("hm")[0].style["fill"] = pathColor;
            }
            
            if(document.getElementsByClassName("inventory")[0].firstChild.style.visibility != "visible" && jj == 3 && ii == 4)
            {
                thisSquare.getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend",'<circle style="fill:#FF0000" cx="20" cy="15" r="3"/>');
            }
            else if(jj == 3 && ii == 4)
            {
                try
                {
                    thisSquare.getElementsByTagName("svg")[0].removeChild(thisSquare.getElementsByTagName("svg")[0].getElementsByTagName("circle")[0]);
                }
                catch{}
            }
            
            if(document.getElementsByClassName("inventory")[1].firstChild.style.visibility != "visible" && jj == 7 && ii == 11)
            {
                thisSquare.getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend",'<circle style="fill:#FF0000" cx="15" cy="20" r="3"/>');
            }
            else if(jj == 7 && ii == 11)
            {
                try
                {
                    thisSquare.getElementsByTagName("svg")[0].removeChild(thisSquare.getElementsByTagName("svg")[0].getElementsByTagName("circle")[0]);
                }
                catch{}
            }
            
            if(document.getElementsByClassName("inventory")[2].firstChild.style.visibility != "visible" && jj == 1 && ii == 17)
            {
                thisSquare.getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend",'<circle style="fill:#FF0000" cx="20" cy="25" r="3"/>')
            }
            else if(jj == 1 && ii == 17)
            {
                try
                {
                    thisSquare.getElementsByTagName("svg")[0].removeChild(thisSquare.getElementsByTagName("svg")[0].getElementsByTagName("circle")[0]);
                }
                catch{}
            }
            
            if(document.getElementsByClassName("inventory")[4].firstChild.style.visibility != "visible" && jj == 16 && ii == 6)
            {
                thisSquare.getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend",'<circle style="fill:#FF0000" cx="25" cy="20" r="3"/>')
            }
            else if(jj == 16 && ii == 6)
            {
                try
                {
                    thisSquare.getElementsByTagName("svg")[0].removeChild(thisSquare.getElementsByTagName("svg")[0].getElementsByTagName("circle")[0]);
                }
                catch{}
            }
            
            if(document.getElementsByClassName("inventory")[5].firstChild.style.visibility != "visible" && jj == 14 && ii == 16)
            {
                thisSquare.getElementsByTagName("svg")[0].insertAdjacentHTML("beforeend",'<circle style="fill:#FF0000" cx="20" cy="15" r="3"/>')
            }
            else if(jj == 14 && ii == 16)
            {
                try
                {
                    thisSquare.getElementsByTagName("svg")[0].removeChild(thisSquare.getElementsByTagName("svg")[0].getElementsByTagName("circle")[0]);
                }
                catch{}
            }
        }
    
    
    

    
    
    
    
    </script>
    
    
</html>



