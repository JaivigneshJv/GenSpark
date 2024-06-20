const {JSDOM} = require("jsdom");
//import {JSDOM} from 'jsdom';

test("simple button click", () => {
  const dom = new JSDOM(
    `
        <!DOCTYPE html>
        <html>
            <body>
                <button id="btn">Click me</button>
                <p id="demo"></p>
                <script>
                    document.getElementById('btn').addEventListener('click',()=>{
                        document.getElementById('demo').innerHTML = 'Hello World';
                    });
                </script>
            </body>
        </html>`,
    {runScripts: "dangerously", resources: "usable"}
  );
  //Raising the event
  dom.window.document.getElementById("btn").click();
  const actual = dom.window.document.getElementById("demo").innerHTML;
  expect(actual).toBe("Hello World");
});
