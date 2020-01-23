import { createAction } from 'typesafe-actions';
import { IAnimalsResponse, ISavedAnimalsCountResponse, AnimalKind } from "../../../../../api/animals";
import { IRequestParams, RequestFilterOperators } from '../../../../../api/requestOptions';

export const actionFetchAnimalsRequest = createAction(
  'FETCH_ANIMALS_REQUEST',
  (resolve) => (requestParams?: IRequestParams) => resolve(requestParams)
);
export const actionFetchAnimalsSuccess = createAction(
  'FETCH_ANIMALS_SUCCESS',
  (resolve) => (data: IAnimalsResponse) => resolve({ data })
);
export const actionFetchAnimalsFailure = createAction(
  'FETCH_ANIMALS_FAILURE',
  (resolve) => (error: Error) => resolve({ error })
);
export const actionFetchDogsRequest = createAction(
  'FETCH_DOGS_REQUEST',
  (resolve) => (requestParams?: IRequestParams) => resolve({
    ...requestParams,
    filter: {
      fieldName: 'kindOfAnimal',
      opeartor: RequestFilterOperators.ALL,
      value: AnimalKind.DOG
    }
  })
);
export const actionFetchDogsSuccess = createAction(
  'FETCH_DOGS_SUCCESS',
  (resolve) => (data: IAnimalsResponse) => resolve(data)
);
export const actionFetchDogsFailure = createAction(
  'FETCH_DOGS_FAILURE',
  (resolve) => (error: Error) => resolve({ error })
);
export const actionFetchCatsRequest = createAction(
  'FETCH_CATS_REQUEST',
  (resolve) => (requestParams?: IRequestParams) => resolve({
    ...requestParams,
    filter: {
      fieldName: 'kindOfAnimal',
      opeartor: RequestFilterOperators.ALL,
      value: AnimalKind.CAT
    }
  })
);
export const actionFetchCatsSuccess = createAction(
  'FETCH_CATS_SUCCESS',
  (resolve) => (data: IAnimalsResponse) => resolve(data)
);
export const actionFetchCatsFailure = createAction(
  'FETCH_CATS_FAILURE',
  (resolve) => (error: Error) => resolve({ error })
);
export const actionFetchSickAnimals = createAction(
  'FETCH_SICK_ANIMALS',
  (resolve) => () => resolve({})
);
export const actionFetchSickAnimalsSuccess = createAction(
  'FETCH_SICK_ANIMALS_SUCCESS',
  (resolve) => (data: any) => resolve({ data })
);
export const actionFetchSickAnimalFailUrl = createAction(
  'FETCH_ANIMALS_FAILURL',
  (resolve) => (error: Error) => resolve({ error })
)
export const actionFetchSavedAnimalsCount = createAction(
  'FETCH_SAVED_ANIMALS_COUNT',
  (resolve) => () => resolve()
)
export const actionFetchSavedAnimalsCountSuccess = createAction(
  'FETCH_SAVED_ANIMALS_COUNT_SUCCESS',
  (resolve) => (data: ISavedAnimalsCountResponse) => resolve(data)
);
export const actionFetchSavedAnimalsCountFailure = createAction(
  'FETCH_SAVED_ANIMALS_COUNT_FAILURE',
  (resolve) => (error: Error) => resolve({ error })
);