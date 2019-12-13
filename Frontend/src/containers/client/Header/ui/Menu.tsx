import React from "react";
import {TI18n} from "../../../../i18n";
import "../styles/menu.scss"
import {ReactComponent as HeartLogo} from '../../../../assets/header/heart.svg';

export const AppMenu: React.FC = () => {
    return (
        <div className="header-menu">
            <div className="item"><TI18n keyStr="headerMenuItem1" default="В приюте"/></div>
            <div className="item"><TI18n keyStr="headerMenuItem2" default="Наши животные"/></div>
            <div className="item"><TI18n keyStr="headerMenuItem3" default="Как я могу помочь?"/></div>
            <div className="item"><TI18n keyStr="headerMenuItem4" default="Блог"/></div>
            <div className="item"><TI18n keyStr="headerMenuItem5" default="Контакты"/></div>
            <div className="item"><HeartLogo/></div>
            <div className="help-button"><span><TI18n keyStr="headerMenuItem6" default="Помощь"/></span></div>
        </div>
    )
};