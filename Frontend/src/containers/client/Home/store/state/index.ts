import { IRequestState, DEFAULT_REQUEST_STATE } from "../../../../../api";
import { IInfoCard } from './../../../../../api/infoCard';
import { IBlogListResponse } from './../../../../../api/blog';

export interface IHomePageState {
    blogList: IBlogListResponse;
    blogListRequestState: IRequestState;
    blogListSaved: IBlogListResponse;
    blogListSavedRequestState: IRequestState;
    isActivePopup: boolean;
    infoCardState: IRequestState;
    infoCard: IInfoCard;
}

export const DEFAULT_INFO_CARD = {
    data: {
       bankCard: {
         cardNumber: '',
         edrpou: '',
         bankName: '',
         firstName: '',
         lastName: '',
       },
       title: '',
       body: '',
     }
}
export const DEFAULT_BLOGS: IBlogListResponse = {
  data: [],
  pageCount: 0,
  pageNumber: 0,
  pageSize: 0,
  self: '',
  totalCount: 0
};

export const DEFAULT_HOME_PAGE_STATE: IHomePageState = {
  blogList: {...DEFAULT_BLOGS},
  blogListRequestState: { ...DEFAULT_REQUEST_STATE},
  blogListSaved: {...DEFAULT_BLOGS},
  blogListSavedRequestState: { ...DEFAULT_REQUEST_STATE},
  isActivePopup:  false,
  infoCardState: { ...DEFAULT_REQUEST_STATE},
  infoCard:{...DEFAULT_INFO_CARD},
};