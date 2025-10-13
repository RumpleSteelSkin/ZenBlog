import {HttpHandlerFn, HttpInterceptorFn, HttpRequest} from '@angular/common/http';

export const TokenInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next:
HttpHandlerFn) => {
  const userToken = localStorage.getItem('angular_token');
  if (userToken) {
    const modifiedReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${userToken}`),
    });
    return next(modifiedReq);
  } else return next(req);
};
