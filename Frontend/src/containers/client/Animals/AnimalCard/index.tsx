import React from 'react';
import { IAnimal, Gender } from '../../../../api/animals';
import './index.scss';
import { BASE_URL } from '../../../../api';
import noPhotoImage from './../../../../img/nophoto.jpg';
import { TI18n } from '../../../../i18n';
import { Link } from 'react-router-dom';
import { ButtonLike } from '../../../../components/ButtonLike';

interface IPropTypes {
  animal: IAnimal;
}

export const AnimalCard: React.FC<IPropTypes> = ({ animal }) => {
  return (
    <div className="animal-card">
      <ButtonLike id={animal.id} />
      <Link to={`/animals/${animal.id}`}>
        <div className="img-holder" style={{ backgroundImage: `url(${animal.imageIds[0] ? `${BASE_URL}documents/${animal.imageIds[0]}/type/medium` : `${noPhotoImage}`})` }}>
        </div>
        <strong className="animal-name">{animal.name}</strong>
        <div className="description">
          <TI18n keyStr={
            !!animal.gender && (animal.gender.toLowerCase() === Gender.MALE || animal.gender.toLowerCase() === Gender.FEMALE) ?
              animal.gender.toLowerCase() : 'unknownGender'} default="Пол неизвестен" />, {
            (!!animal.age || animal.age === 0) && <React.Fragment>{animal.age} <TI18n keyStr='month' default="месяцев" /></React.Fragment>}
        </div>
      </Link>
    </div>    
  )
};