let userResponce = false;

function SetAttributes(text)
{
    //Получение элементов.
    let elements = document.getElementsByClassName("word_without_translate");
    let textSplit = text.split("\r\n");

    //Добавление атрибута тултипа.
    for (i = 0; i < elements.length; i++)
    {
        elements[i] = elements[i].setAttribute("data-tooltip", textSplit[i]);
    }
}

//Проверка url адреса страницы.
function CheckUrl(url)
{
    if (url.includes("table-theme/tatarcha/tatarcha_"))
    {
        userResponce = confirm("Вы хотите видеть переводы слов при наведении на них?");

        Start(userResponce);
    }
}

function Start(userResponce)
{
    if (userResponce) {
        console.log("klsgp");
        let toolTipBox;

        //Функция активации тултипа.
        document.onmouseover = function GetToolTip(e) {
            let target = e.target;
            let toolTipText = target.dataset.tooltip;

            if (!toolTipText) return;

            //Создание и добавление элемента в дерево.
            toolTipBox = document.createElement('div');
            toolTipBox.className = "toolTip"
            toolTipBox.innerHTML = toolTipText;

            toolTipBox.style.cssText += `
        display: inline-block;
        margin-left: 5%;
        padding: 0.7%;`;

            target.append(toolTipBox);
        }

        //Дизактивация тултипа.
        document.onmouseout = function RemoveToolTip(e) {
            if (toolTipBox) {
                toolTipBox.remove();
                toolTipBox = null;
            }
        }
    }
}