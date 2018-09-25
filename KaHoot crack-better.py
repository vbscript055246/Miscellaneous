# python 內建
from time import sleep
import os
import re


# 以下要裝
# selenium動態爬蟲工具
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import selenium.webdriver.support.ui as ui

# BeautifulSoup靜態爬蟲工具
from bs4 import BeautifulSoup


# 常數宣告區
NEXT_BUTTON_XPATH = '//button[@type="submit"]'

ANS_BUTTON_XPATH = ['card-button--triangle',
                    'card-button--diamond',
                    'card-button--circle',
                    'card-button--square']



ID  = input()   # 取得房間ID

browser = webdriver.Chrome()    # 生成模擬瀏覽器物件 有其他瀏覽器可以選
wait = ui.WebDriverWait(browser,100000) # 生成等待物件 負責等網頁跑完的相關事項 100000是等待時間的最大值

# 開四個新分頁到kahoot
for i in range(4):
    browser.execute_script("window.open('about:blank', 't{}');".format(i)) # 開一個新分頁 
    browser.switch_to.window("t{}".format(i))   # 把畫面轉到剛剛開的分頁
    browser.get("https://kahoot.it/")   # 在網址輸入kahoot 讓畫面到kahoot
    wait.until(lambda browser: browser.find_element_by_id('inputSession').is_displayed())   # 等網頁跑好
    browser.find_element_by_id('inputSession').send_keys(ID)    # 輸入房間ID
    sleep(0.01) # 怕網頁還沒很完整的跑完
    browser.find_element_by_xpath(NEXT_BUTTON_XPATH).click()    # 按下加入遊戲的按鈕
    #sleep(0.01)

# 創四個帳號進到遊戲準備畫面
for i in range(4):
    browser.switch_to.window("t{}".format(i)) # 把畫面轉到第i個分頁
    wait.until(lambda browser: browser.find_element_by_id('username').is_displayed())   # 確定畫面跑完了
    browser.find_element_by_id('username').send_keys("Robot.{}".format(i))  # 輸入帳號名
    wait.until(lambda browser: browser.find_element_by_xpath(NEXT_BUTTON_XPATH).is_displayed()) # 確定畫面跑完了
    sleep(0.25) # 怕網頁還沒很完整的跑完
    browser.find_element_by_xpath(NEXT_BUTTON_XPATH).click()    # 按下加入準備好了的按鈕
    sleep(0.25)


# ===============================準備好要答題了======================================

while(1):   # 可能有很多題
    for i in range(4):
        sleep(0.05) # 怕電腦連續切分頁跑太慢
        browser.switch_to.window("t{}".format(i))   # 把畫面轉到第i個分頁
        wait.until(lambda browser: browser.find_element_by_id("gameBlockIframe").is_displayed())    # 確定畫面跑完了
        browser.switch_to.frame(browser.find_element_by_id("gameBlockIframe"))  # 動態爬蟲操作 browser改成進到頁面框架內
        sleep(0.05) # 怕電腦跑太慢
        browser.find_element_by_class_name(ANS_BUTTON_XPATH[i]).click() # 根據"i"選擇答案猜 細節去看ANS_BUTTON_XPATH

    sleep(0.25) # 答完一輪 怕電腦心很累

    # 確認答題結果
    for i in range(4):
        sleep(0.01) # 怕電腦連續切分頁跑太慢
        browser.switch_to.window("t{}".format(i))   # 把畫面轉到第i個分頁
        browser.switch_to.default_content() # 動態爬蟲操作 讓browser改成抓結果的頁面
        wait.until(lambda browser: browser.find_element_by_css_selector(".message-wrapper").is_displayed()) # 確定畫面跑完了

        # 標準靜態爬蟲操作
        html_source = browser.page_source # 取得目前browser上的網頁原始碼
        soup = BeautifulSoup(html_source, 'html.parser')    # 生成BeautifulSoup物件並選定讀取原始碼的方式
        text = soup.select_one('.message-result h1').text   # 從中找到答對答錯
        if text == 'Correct':   # 如果猜對了
            print(ANS_BUTTON_XPATH[i])  # 對的答案在這裡輸出
            break
        
    # 題目是否答完了
    try:
        End = ui.WebDriverWait(browser,60) # 新的等待物件 弄新的是為了縮短延遲
        End.until(lambda browser: browser.find_element_by_class_name("ranking-screen-header").is_displayed())   # 看頁面是否刷新

        # 標準靜態爬蟲操作
        html_source = browser.page_source
        soup = BeautifulSoup(html_source, 'html.parser')
        if len(soup.select('.ranking-screen-header'))!=0:   #   遊戲結束也有名次出來了的話
            break # 結束程序
    except:
        sleep(0.01)
        
browser.quit()  # 關閉模擬瀏覽器視窗
